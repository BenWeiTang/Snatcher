using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public class InvisMoveState : ASubState
    {
        private Vector3 _currentDirection;
        public InvisMoveState(PlayerStateMachine currentContext) : base(currentContext) { }

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");

            Context.PlayerInput.Player.Movement.canceled += OnMovementCanceled;
            Context.PlayerInput.Player.UseAbility.performed+= OnAbilityPressed;
            Context.Animator.SetBool(SuperState.IsMovingHash, true);
        }


        public override void ExitState()
        {
            Context.PlayerInput.Player.Movement.canceled -= OnMovementCanceled;
            Context.PlayerInput.Player.UseAbility.performed -= OnAbilityPressed;
            Context.Animator.SetBool(SuperState.IsMovingHash, false);
        }

        public override void UpdateState()
        {
            UpdateDirection();
            UpdateRotation();
            UpdateMovement();
            CheckSwitchState();
        }

        protected override void CheckSwitchState()
        {
            if (!Context.Controller.isGrounded)
            {
                if (FrontGroundCheck())
                    return;
                
                // If we are falling, first go back to idle to exit ability animation sub state machine
                // The idle state will handle the falling transition automatically
                Context.SwitchSubState(Factory.Idle);
            }
        }

        private void OnMovementCanceled(InputAction.CallbackContext callbackContext) => Context.SwitchSubState(Factory.InvisIdle);

        private void OnAbilityPressed(InputAction.CallbackContext callbackContext) => Context.SwitchSubState(Factory.Idle);
        
        private void UpdateDirection()
        {
            Vector2 currentInput = Context.PlayerInput.Player.Movement.ReadValue<Vector2>();
            _currentDirection.x = currentInput.x;
            _currentDirection.z = currentInput.y;
            _currentDirection = _currentDirection.ToIso();
        }
        
        private void UpdateRotation()
        {
            Vector3 positionToLookAt = _currentDirection;
            
            if (positionToLookAt.sqrMagnitude == 0)
                return;
            
            Quaternion currentRotation = Context.transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            Context.transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, SuperState.StateConfig.TurnSpeed * Time.deltaTime);
        }
        
        private void UpdateMovement()
        {
            Vector3 velocity = _currentDirection;
            velocity *= SuperState.StateConfig.MoveSpeed;
            velocity.y = SuperState.StateConfig.GroundedGravity;
            
            //TODO: make the speed reduction configurable
            Context.Controller.Move(((0.5f * velocity) * LimbManager.Instance.GetWeightConsequenceModifier()) * Time.deltaTime);
        }
    }
}