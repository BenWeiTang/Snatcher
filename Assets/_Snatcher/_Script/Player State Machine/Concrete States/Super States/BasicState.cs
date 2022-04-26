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
        
        //TODO: change isthrowinghash to use this
        public sealed override int IsEnteringAbilityHash { get; protected set; }

        public BasicState(PlayerStateMachine currentContext) : base(currentContext)
        {
            IsMovingHash = Animator.StringToHash("IsMoving");
            IsFallingHash = Animator.StringToHash("IsFalling");
            IsEnteringAbilityHash = Animator.StringToHash("IsHooking");
        }

        public override void EnterState()
        {
            base.EnterState();
            AbilityEntryState = Factory.HookOut;
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