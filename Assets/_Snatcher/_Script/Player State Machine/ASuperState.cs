using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public abstract class ASuperState : APlayerState
    {
        protected ASuperState(PlayerStateMachine currentContext) : base(currentContext)
        {
        }

        public abstract PlayerStateConfig StateConfig { get; set; }
        public abstract ASubState AbilityEntryState { get; protected set; }
        public abstract int IsMovingHash { get; protected set; }
        public abstract int IsFallingHash { get; protected set; }
        public abstract int IsThrowingHash { get; protected set; }

        public override void EnterState()
        {
            Context.PlayerInput.Player.SwitchLimb.started += OnSwitchLimbPressed;
        }

        public override void ExitState()
        {
            Context.PlayerInput.Player.SwitchLimb.started -= OnSwitchLimbPressed;
        }

        private void OnSwitchLimbPressed(InputAction.CallbackContext callbackContext)
        {
            bool goNext = callbackContext.ReadValue<float>() > 0;
            
            // Update the current index inside LimbManager
            LimbManager.Instance.SwitchLimb(goNext);
            var upcomingState = LimbManager.Instance.CurrentLimb.SuperState;
            if (upcomingState != null)
            {
                Context.SwitchSuperState(LimbManager.Instance.CurrentLimb.SuperState);
            }
        }
    }
}