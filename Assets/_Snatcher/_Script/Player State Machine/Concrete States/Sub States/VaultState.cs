using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace Snatcher
{
    public class VaultState : ASubState
    {
        private Vector3 _apex;
        private TweenerCore<Vector3, Vector3, VectorOptions> _vaultUpTween;

        public VaultState(PlayerStateMachine currentContext) : base(currentContext) { }

        //TODO: set animations once they are ready
        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");

            CalculateWaypoints();
            if (LimbManager.Instance.EatLimbStaminaCost())
            {
                VaultUp();
            }
            else
            {
                Context.SwitchSubState(Factory.Idle);
            }
        }

        //TODO: set animations once they are ready
        public override void ExitState() { }

        public override void UpdateState() => CheckSwitchState();

        protected override void CheckSwitchState() => ForwardOrDownwardCheck();

        private void CalculateWaypoints()
        {
            Transform t = Context.transform;
            Vector3 tPos = t.position;
            Vector3 tForward = t.forward;

            //TODO: parameterize distance and height
            _apex = tPos + 4f * tForward;
            _apex.y += 5f;
        }

        private void VaultUp()
        {
            _vaultUpTween = Context.transform.DOMove(_apex, 0.25f).SetEase(Ease.OutQuad);
            _vaultUpTween.onComplete += () =>
            {
                Context.SwitchSubState(Factory.Idle);
            };
        }
        
        private void ForwardOrDownwardCheck()
        {
            if (!ForwardGroundCheck(0.25f))
                return;

            _vaultUpTween.Pause();
            _vaultUpTween.Kill();
            Context.SwitchSubState(Factory.Idle);
        }
    }
}