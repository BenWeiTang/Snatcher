using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Snatcher
{
    public class PlayerBasicDashState : APlayerBasicState
    {
        private Vector3 _dashDirection;
        private Vector3 _destination;

        public PlayerBasicDashState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        public override async void EnterState(bool hasSameSuperState)
        {
            if (Context.Debug) this.Log("Enter");
            
            base.EnterState(hasSameSuperState);
            _dashDirection = Context.transform.forward;
            CalculateDestination();
            await DoDash();
        }

        public override void ExitState() { }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }

        private void CalculateDestination()
        {
            _destination = Context.transform.position + _dashDirection * StateConfig.DashDistance;
        }

        private async Task DoDash()
        {
            await Context.transform.DOMove(_destination, StateConfig.DashDuration).SetEase(StateConfig.EaseMode).AsyncWaitForCompletion();
            Context.SwitchState(Factory.BasicIdle, true);
        }
    }
}