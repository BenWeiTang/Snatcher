using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace Snatcher
{
    public class DashState : ASubState
    {
        private Vector3 _dashDirection;
        private Vector3 _destination;
        private TweenerCore<Vector3, Vector3, VectorOptions> _dashTween;

        public DashState(PlayerStateMachine currentContext) : base(currentContext) { }

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");

            _dashDirection = Context.transform.forward;
            CalculateDestination();
            Context.Animator.SetBool(SuperState.IsDashingHash, true);
            DoDash();
        }

        public override void ExitState()
        {
            Context.Animator.SetBool(SuperState.IsDashingHash, false);
        }

        public override void UpdateState() => CheckSwitchState();

        protected override void CheckSwitchState() => ForwardCheck();

        private void CalculateDestination()
        {
            _destination = Context.transform.position + _dashDirection * SuperState.StateConfig.DashDistance;
        }

        private void DoDash()
        {
            _dashTween = Context.transform.DOMove(_destination, SuperState.StateConfig.DashDuration).SetEase(SuperState.StateConfig.EaseMode);
            _dashTween.SetAutoKill(false);
            _dashTween.onComplete += () =>
            {
                Context.SwitchSubState(Factory.Idle);
            };
        }

        private void ForwardCheck()
        {
            if (!ForwardGroundCheck(0.25f))
                return;
            
            _dashTween.Pause();
            _dashTween.Kill();
            Context.SwitchSubState(Factory.Idle);
        }
    }
}