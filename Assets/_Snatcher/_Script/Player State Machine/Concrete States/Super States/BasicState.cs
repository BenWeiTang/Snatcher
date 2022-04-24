using UnityEngine;
using UnityEngine.InputSystem;

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
            Context.PlayerInput.Player.SwitchLimb.started += OnSwitchLimbPressed;
        }

        public override void ExitState()
        {
            Context.PlayerInput.Player.SwitchLimb.started -= OnSwitchLimbPressed;
        }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }

        private void OnSwitchLimbPressed(InputAction.CallbackContext callbackContext)
        {
            var nextLimbType = LimbManager.Instance.NextLimb.Type;
            switch (nextLimbType)
            {
                case LimbType.Basic:
                    Context.SwitchSuperState(Factory.BasicState);
                    break;
                case LimbType.Invis:
                    Context.SwitchSuperState(Factory.InvisState);
                    break;
                default:
                    Context.SwitchSuperState(Factory.BasicState);
                    break;
            }
        }
    }
}