using UnityEngine;

namespace Snatcher
{
    public class BasicState : ASuperState
    {
        public override PlayerStateConfig StateConfig { get; set; } = StateConfigManager.Instance.BasicStateConfig;
        public sealed override ASubState AbilityEntryState { get; protected set; }
        public sealed override int IsMovingHash { get; protected set; }
        public sealed override int IsFallingHash { get; protected set; }
        public sealed override int IsThrowingHash { get; protected set; }

        public BasicState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory)
        {
            AbilityEntryState = Factory.Idle;
            IsMovingHash = Animator.StringToHash("IsMoving");
            IsFallingHash = Animator.StringToHash("IsFalling");
            IsThrowingHash = Animator.StringToHash("IsThrowing");
        }

        public override void EnterState()
        {
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
        }

        protected override void CheckSwitchState()
        {
        }
    }
}