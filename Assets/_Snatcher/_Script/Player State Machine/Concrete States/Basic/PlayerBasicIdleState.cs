using UnityEngine.InputSystem;

namespace Snatcher
{
    public class PlayerBasicIdleState : APlayerBasicState
    {
        public PlayerBasicIdleState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        public override void EnterState(bool hasSameSuperState)
        {
            base.EnterState(hasSameSuperState);
            Context.PlayerInput.Player.Movement.started += OnMovementStarted;
        }

        public override void ExitState()
        {
            // IMPORTANT!!! Make sure you unsubscribe from the event when exiting this state
            Context.PlayerInput.Player.Movement.started -= OnMovementStarted;
        }

        public override void UpdateState()
        {
            base.UpdateState();
            CheckSwitchState();
        }

        protected override void CheckSwitchState() { }

        // When the movement started, we want to transition to PlayerBasicMoveState
        // Since PlayerBasicMoveState and our current state, PlayerBasicIdleState, have the same Super State, APlayerBasicState,
        // we pass in the argument true
        private void OnMovementStarted(InputAction.CallbackContext callbackContext) => Context.SwitchState(Factory.BasicMove, true);
    }
}