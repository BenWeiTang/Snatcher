using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public abstract class ASuperState : APlayerState
    {
        public abstract PlayerStateConfig StateConfig { get; set; }
        public abstract ASubState AbilityEntryState { get; protected set; }
        public int IsMovingHash { get; }
        public int IsFallingHash { get; }
        public int IsDashingHash { get; }
        public int IsAbilityActiveHash { get; protected set; }
        public abstract int IsInSuperStateHash { get; protected set; }

        protected ASuperState(PlayerStateMachine currentContext) : base(currentContext)
        {
            IsMovingHash = Animator.StringToHash("IsMoving");
            IsFallingHash = Animator.StringToHash("IsFalling");
            IsDashingHash = Animator.StringToHash("IsDashing");
            IsAbilityActiveHash = Animator.StringToHash("IsAbilityActive");
        }

        public override void EnterState()
        {
            Context.PlayerInput.Player.SwitchLimb.started += OnSwitchLimbPressed;
            Context.Animator.SetBool(IsInSuperStateHash, true);
        }

        public override void ExitState()
        {
            Context.PlayerInput.Player.SwitchLimb.started -= OnSwitchLimbPressed;
            Context.Animator.SetBool(IsInSuperStateHash, false);
        }

        private void OnSwitchLimbPressed(InputAction.CallbackContext callbackContext)
        {
            bool goNext = callbackContext.ReadValue<float>() > 0;

            // Update the current index inside LimbManager
            LimbManager.Instance.SwitchLimb(goNext);
            var upcomingState = LimbManager.Instance.CurrentLimb.SuperState;
            if (upcomingState != Context.CurrentSuperState)
            {
                Context.SwitchSuperState(upcomingState);

                // If we enter this clause, it means we want to switch Super States
                // Therefore, we want to exit out whatever Ability State we were previously in, if applicable
                Context.Animator.SetBool(IsAbilityActiveHash, false);
            }
        }
    }
}