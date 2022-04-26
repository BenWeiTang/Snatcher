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
            
            // This state is the entry state of basic, so we always set animation bool to true here
            Context.Animator.SetBool(SuperState.IsEnteringAbilityHash, true);
            
            //TODO: remove later
            // If we can be in hook out, we must be in basic super state
            // When we enter this state, we used the ability once
            LimbManager.Instance.DecrementLimbDurability();

            await HandleHitBoxActivation();
        }

        public override void ExitState()
        {
            Context.HookController.OnEnemyHit -= OnHookHitEnemy;
            Context.HookController.OnGrappleHit -= OnHootHitGrapple;
            Context.HookController.ActivateCollider(false);
            Context.Animator.SetBool(SuperState.IsEnteringAbilityHash, false);
        }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
        
        //TODO: depending on what enemy is hit, transition to a different state
        private void OnHookHitEnemy()
        {
            _hit = true;
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