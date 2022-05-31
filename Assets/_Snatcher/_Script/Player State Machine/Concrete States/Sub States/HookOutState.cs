using System.Threading.Tasks;
using UnityEngine;

namespace Snatcher
{
    public class HookOutState : ASubState
    {
        private bool _hit;
        public HookOutState(PlayerStateMachine currentContext) : base(currentContext) { }

        public override async void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            
            Context.HookController.OnEnemyHit += OnHookHitEnemy;
            Context.HookController.OnGrappleHit += OnHootHitGrapple;
            Context.PlayerInput.Player.SwitchLimb.Disable();
            
            // If we can be in hook out, we must be in basic super state
            // When we enter this state, we used the ability once if we have the stamina to do so
            if (LimbManager.Instance.EatLimbStaminaCost())
            {
                // This state is the entry state of basic, so we always set animation bool to true here
                Context.Animator.SetBool(SuperState.IsAbilityActiveHash, true);
                await HandleHitBoxActivation();
            }
        }

        public override void ExitState()
        {
            Context.HookController.OnEnemyHit -= OnHookHitEnemy;
            Context.HookController.OnGrappleHit -= OnHootHitGrapple;
            Context.HookController.ActivateCollider(false);
            Context.HookController.ResetRotation();
            Context.Animator.SetBool(SuperState.IsAbilityActiveHash, false);
            Context.PlayerInput.Player.Enable();
        }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
        
        private void OnHookHitEnemy(LimbType type)
        {
            _hit = true;
            
            // Note: Adding a Limb to LimbManager's collection will also cause the FSM to switch SuperState if succeeded
            LimbManager.Instance.TryAddLimb(type);
            
            Context.SwitchSubState(Factory.Idle);
        }

        private void OnHootHitGrapple(Vector3 grappleDestination)
        {
            _hit = true;
            if (Context.CanGrapple)
            {
                Context.GrappleDestination = grappleDestination;
                Context.SwitchSubState(Factory.GrappleToward);
            }
        }
        
        private async Task HandleHitBoxActivation()
        {
            await Task.Delay((int)(SuperState.StateConfig.StartupWindow * 1_000));
            Context.HookController.ActivateCollider(true);
            
            float exitTime = Time.time + SuperState.StateConfig.ActiveWindow;
            _hit = false;
            
            // If nothing is hit yet AND time is not exit time yet, keep looping
            while (!_hit && Time.time < exitTime)
            {
                await Task.Yield();
            }

            // If we reach this point because time is up not because we hit something
            // We want to transition back to idle
            if (!_hit)
            {
                Context.SwitchSubState(Factory.Idle);
            }
        }
    }
}