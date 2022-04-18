﻿using UnityEngine;
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
            // Call Super state EnterState method to handle transitioning from a state whose super state isn't APlayerBasicState
            base.EnterState(hasSameSuperState);
            
            // Subscribe to the canceled event on Movement
            Context.PlayerInput.Player.Movement.canceled += OnMovementCanceled;
            
            // When entering this state, transition the animation state to Run by setting the bool "IsMoving" to true
            Context.Animator.SetBool(_isMovingHash, true);
        }

        public override void ExitState()
        {
            // IMPORTANT!!! Make sure you unsubscribe from the event when exiting this state
            Context.PlayerInput.Player.Movement.canceled -= OnMovementCanceled;
            
            // When exiting this state, transition the animation state to Idle by setting the bool "IsMoving" to false
            Context.Animator.SetBool(_isMovingHash, false);
        }

        // UpdateState is called every frame from the Context (state machine)
        public override void UpdateState()
        {
            base.UpdateState();
            UpdateDirection();
            UpdateRotation();
            UpdateMovement();
            // CheckSwitchState();
        }

        // CheckSwitchState should ONLY be called in the UpdateState method
        // For now the CheckSwitchState does absolutely NOTHING
        // This is because Basic Move State only relies on one event callback to know when to switch states
        protected override void CheckSwitchState(){ }

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
            positionToLookAt.y = 0f;
            
            if (positionToLookAt.sqrMagnitude == 0)
                return;
            
            Quaternion currentRotation = Context.transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            Context.transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, StateConfig.TurnSpeed * Time.deltaTime);
        }

        // The actual handling of the Character Controller movement using the Move method
        // Note that to avoid calculation errors, there should only be ONE call to the Move method per Update cycle
        private void UpdateMovement() => Context.Controller.Move(_currentDirection * (StateConfig.MoveSpeed * Time.deltaTime));
    }
}