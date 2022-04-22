using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace Snatcher
{
    public class DashState : ASubState
    {
        private Vector3 _dashDirection;
        private Vector3 _destination;
        
        public DashState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        public override async void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            
            _dashDirection = Context.transform.forward;
            CalculateDestination();
            await DoDash();
        }

        public override void ExitState() { }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
        
        private void CalculateDestination()
        {
            _destination = Context.transform.position + _dashDirection * SuperState.StateConfig.DashDistance;
        }
        
        private async Task DoDash()
        {
            await Context.transform.DOMove(_destination, SuperState.StateConfig.DashDuration).SetEase(SuperState.StateConfig.EaseMode).AsyncWaitForCompletion();
            Context.SwitchSubState(Factory.Idle);
        }
    }
}