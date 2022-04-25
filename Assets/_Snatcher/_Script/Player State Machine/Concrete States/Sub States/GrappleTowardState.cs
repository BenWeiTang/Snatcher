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
            //TODO: add duration and ease mode to config
            // Stop before the grapple post
            Vector3 destination = (Context.transform.position - Context.GrappleDestination).normalized * 0.5f + Context.GrappleDestination;
            destination.y = Context.transform.position.y;
            await Context.transform.DOMove(destination, 1f).SetEase(Ease.OutQuad).AsyncWaitForCompletion();
            Context.SwitchSubState(Factory.Idle);
        }
    }
}