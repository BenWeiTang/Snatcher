using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace Snatcher
{
    public class GrappleTowardState : ASubState
    {
        public GrappleTowardState(PlayerStateMachine currentContext) : base(currentContext) { }

        public override async void EnterState()
        {
            if (Context.Debug) this.Log("Enter");

            await DoGrappleToward();
        }

        public override void ExitState() { }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }

        private async Task DoGrappleToward()
        {
            // Stop before the grapple post
            Transform ct = Context.transform;
            Vector3 playerPos = ct.position;
            Vector3 grapplePosition = Context.GrappleDestination;
            grapplePosition.y = playerPos.y;
            
            Vector3 forward = (grapplePosition - playerPos).normalized;
            Vector3 destination = -1f * forward + grapplePosition;
            await ct.DOMove(destination, 0.5f).SetEase(Ease.OutQuint).AsyncWaitForCompletion();
            Context.SwitchSubState(Factory.Idle);
        }
    }
}