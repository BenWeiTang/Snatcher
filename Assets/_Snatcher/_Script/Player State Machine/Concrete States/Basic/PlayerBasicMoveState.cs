using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public class PlayerBasicMoveState : APlayerBasicState
    {
        private readonly int _isMovingHash;
        private Vector3 _currentDirection;

        public PlayerBasicMoveState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory)
        {
            _isMovingHash = Animator.StringToHash("IsMoving");
        }

        public override void EnterState(bool hasSameSuperState)
        {
            if (Context.Debug) this.Log("Enter");
            
            // Call Super state EnterState method to handle transitioning from a state whose super state isn't APlayerBasicState
            base.EnterState(hasSameSuperState);
            
            // Subscribe to the canceled event on Movement
            Context.PlayerInput.Player.Movement.canceled += OnMovementCanceled;
            
            // Subscribe to the started event on Dash
            Context.PlayerInput.Player.Dash.started += OnDashPressed;
            
            // Subscribe to the started event on Hook/Snatch
            Context.PlayerInput.Player.Snatch.started += OnHookPressed;
            
            // When entering this state, transition the animation state to Run by setting the bool "IsMoving" to true
            Context.Animator.SetBool(_isMovingHash, true);
        }

        public override void ExitState()
        {
            // IMPORTANT!!! Make sure you unsubscribe from the event when exiting this state
            Context.PlayerInput.Player.Movement.canceled -= OnMovementCanceled;
            Context.PlayerInput.Player.Dash.started -= OnDashPressed;
            Context.PlayerInput.Player.Snatch.started -= OnHookPressed;
            
            // When exiting this state, transition the animation state to Idle by setting the bool "IsMoving" to false
            Context.Animator.SetBool(_isMovingHash, false);
        }

        // UpdateState is called every frame from the Context (state machine)
        public override void UpdateState()
        {
            UpdateDirection();
            UpdateRotation();
            UpdateMovement();
            CheckSwitchState();
        }

        // CheckSwitchState should ONLY be called in the UpdateState method
        protected override void CheckSwitchState()
        {
            if (!Context.Controller.isGrounded)
            {
                if (FrontGroundCheck()) 
                    return;
                Context.SwitchState(Factory.BasicFall, true);
            }
        }

        // When the movement ended, we want to transition to PlayerBasicIdleState
        // Since PlayerBasicIdleState and our current state, PlayerBasicMoveState, have the same Super State, APlayerBasicState,
        // we pass in the argument true
        // Note that switching to another state will cause the ExitState method of this class to be called as well
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

        // Update the rotation of the character so that it faces where it is going towards
        // This method should be called after UpdateDirection
        private void UpdateRotation()
        {
            Vector3 positionToLookAt = _currentDirection;
            
            if (positionToLookAt.sqrMagnitude == 0)
                return;
            
            Quaternion currentRotation = Context.transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            Context.transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, StateConfig.TurnSpeed * Time.deltaTime);
        }
        
        // The actual handling of the Character Controller movement using the Move method
        // Note that to avoid calculation errors, there should only be ONE call to the Move method per Update cycle
        private void UpdateMovement()
        {
            Vector3 velocity = _currentDirection;
            velocity *= StateConfig.MoveSpeed;
            velocity.y = StateConfig.GroundedGravity;
            
            Context.Controller.Move(velocity * Time.deltaTime);
        }
        
        private void OnDashPressed(InputAction.CallbackContext _) => Context.SwitchState(Factory.BasicDash, true);

        private void OnHookPressed(InputAction.CallbackContext _) => Context.SwitchState(Factory.BasicHookOut, true);
    }
}