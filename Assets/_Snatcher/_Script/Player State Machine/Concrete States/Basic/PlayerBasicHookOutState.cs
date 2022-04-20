using System.Threading.Tasks;
using UnityEngine;

namespace Snatcher
{
    public class PlayerBasicHookOutState : APlayerBasicState
    {
        // When an enemy is hit, this become true
        private bool _enemyHit;
        public PlayerBasicHookOutState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        public override async void EnterState(bool hasSameSuperState)
        {
            Debug.Log("Hook out");
            base.EnterState(hasSameSuperState);
            Context.HookController.OnEnemyHit += OnHookHitEnemy;
            
            await Task.Delay((int)StateConfig.StartupWindow * 1_000);
            Context.HookController.ActivateCollider(true);
            
            // Reset parameters
            float exitTime = Time.time + StateConfig.ActiveWindow * 1_000;
            _enemyHit = false;
            
            // If the enemy is not hit yet or time is not exit time yet, keep looping
            while (!_enemyHit || Time.time < exitTime)
            {
                await Task.Yield();
            }
            
            // Having exited the loop, it means time is up
            Context.SwitchState(Factory.BasicHookIn, true);
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
            Context.SwitchState(Factory.BasicHookIn, true);
        }
    }
}