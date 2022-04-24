using UnityEngine;

namespace Snatcher
{
    public class InvisState : ASuperState
    {
        public override PlayerStateConfig StateConfig { get; set; } = StateConfigManager.Instance.InvisStateConfig;
        public sealed override ASubState AbilityEntryState { get; protected set; }
        public sealed override int IsMovingHash { get; protected set; }
        public sealed override int IsFallingHash { get; protected set; }
        public sealed override int IsThrowingHash { get; protected set; }

        public InvisState(PlayerStateMachine currentContext) : base(currentContext)
        {
            IsMovingHash = Animator.StringToHash("IsMoving");
            IsFallingHash = Animator.StringToHash("IsFalling");
            IsThrowingHash = Animator.StringToHash("IsThrowing");
        }

        public override void EnterState()
        {
            base.EnterState();
            AbilityEntryState = Factory.InvisIdle;
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void UpdateState()
        {
        }

        protected override void CheckSwitchState()
        {
        }
    }
}