using System.Threading.Tasks;
using UnityEngine;

namespace Snatcher
{
    public class HookOutState : ASubState
    {
        private bool _enemyHit;
        public HookOutState(PlayerStateMachine currentContext) : base(currentContext) { }

        public override async void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            
            Context.HookController.OnEnemyHit += OnHookHitEnemy;
            Context.Animator.SetBool(SuperState.IsThrowingHash, true);

            await HandleHitBoxActivation();

            // Having exited the loop, it means time is up
            Context.SwitchSubState(Factory.HookIn);
        }

        public override void ExitState()
        {
            Context.HookController.OnEnemyHit -= OnHookHitEnemy;
            Context.HookController.ActivateCollider(false);
        }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
        
        //TODO: depending on what enemy is hit, transition to a different state
        private void OnHookHitEnemy()
        {
            _enemyHit = true;
            // Context.SwitchSuperState(Factory.BasicState);
            Context.SwitchSubState(Factory.Idle);
        }
        
        private async Task HandleHitBoxActivation()
        {
            await Task.Delay((int)(SuperState.StateConfig.StartupWindow * 1_000));
            Context.HookController.ActivateCollider(true);
            
            // Reset parameters
            float exitTime = Time.time + SuperState.StateConfig.ActiveWindow;
            _enemyHit = false;
            
            // If the enemy is not hit yet AND time is not exit time yet, keep looping
            while (!_enemyHit && Time.time < exitTime)
            {
                await Task.Yield();
            }
        }
    }
}