using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public class PlayerBasicMoveState : APlayerBasicState
    {
        private Vector3 _currentDirection;
        
        public PlayerBasicMoveState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        public override void EnterState(bool hasSameSuperState)
        {
            base.EnterState(hasSameSuperState);
            Context.PlayerInput.Player.Movement.canceled += OnMovementCanceled;
        }

        public override void ExitState()
        {
            // IMPORTANT!!! Make sure you unsubscribe from the event when exiting this state
            Context.PlayerInput.Player.Movement.canceled -= OnMovementCanceled;
        }

        public override void UpdateState()
        {
            UpdateDirection();
            UpdateRotation();
            UpdateMovement();
            CheckSwitchState();
        }

        protected override void CheckSwitchState(){ }

        // When the movement ended, we want to transition to PlayerBasicIdleState
        // Since PlayerBasicIdleState and our current state, PlayerBasicMoveState, have the same Super State, APlayerBasicState,
        // we pass in the argument true
        private void OnMovementCanceled(InputAction.CallbackContext callbackContext) => Context.SwitchState(Factory.BasicIdle, true);
        
        // Update the value of _currentDirection
        private void UpdateDirection()
        {
            Vector2 currentInput = Context.PlayerInput.Player.Movement.ReadValue<Vector2>();
            _currentDirection.x = currentInput.x;
            _currentDirection.z = currentInput.y;
            
            // Linear transformation so that pressing up key actually cause the character to move forwards (up in monitor space)
            _currentDirection = _currentDirection.ToIso();
        }

        // This method should be called after UpdateDirection
        private void UpdateRotation()
        {
            Vector3 positionToLookAt = _currentDirection;
            positionToLookAt.y = 0f;
            
            if (positionToLookAt.sqrMagnitude == 0)
                return;
            
            Quaternion currentRotation = Context.transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            Context.transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, StateConfig.TurnSpeed * Time.deltaTime);
        }

        private void UpdateMovement() => Context.Controller.Move(_currentDirection * (StateConfig.MoveSpeed * Time.deltaTime));
    }
}