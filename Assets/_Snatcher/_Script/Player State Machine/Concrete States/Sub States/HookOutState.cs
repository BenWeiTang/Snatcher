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
            Context.Animator.SetBool(SuperState.IsThrowingHash, true);

            await HandleHitBoxActivation();

            // Having exited the loop means time is up
            Context.SwitchSubState(Factory.HookIn);
        }

        public override void ExitState()
        {
            Context.HookController.OnEnemyHit -= OnHookHitEnemy;
            Context.HookController.OnGrappleHit -= OnHootHitGrapple;
            Context.HookController.ActivateCollider(false);
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
        }
    }
}