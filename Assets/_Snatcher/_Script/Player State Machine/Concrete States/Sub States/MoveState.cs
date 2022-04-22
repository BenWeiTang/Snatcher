using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public class MoveState : ASubState
    {
        private Vector3 _currentDirection;
        public MoveState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            
            Context.PlayerInput.Player.Movement.canceled += OnMovementCanceled;
            Context.PlayerInput.Player.Dash.started += OnDashPressed;
            Context.PlayerInput.Player.Snatch.started += OnHookPressed;
            Context.Animator.SetBool(SuperState.IsMovingHash, true);
        }

        public override void ExitState()
        {
            Context.PlayerInput.Player.Movement.canceled -= OnMovementCanceled;
            Context.PlayerInput.Player.Dash.started -= OnDashPressed;
            Context.PlayerInput.Player.Snatch.started -= OnHookPressed;
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
                Context.SwitchSubState(Factory.Fall);
            }
        }
        
        private void OnMovementCanceled(InputAction.CallbackContext callbackContext) => Context.SwitchSubState(Factory.Idle);
        
        private void UpdateDirection()
        {
            Vector2 currentInput = Context.PlayerInput.Player.Movement.ReadValue<Vector2>();
            _currentDirection.x = currentInput.x;
            _currentDirection.z = currentInput.y;

            // Linear transformation so that pressing up key actually cause the character to move forwards (up in monitor space)
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
            
            Context.Controller.Move(velocity * Time.deltaTime);
        }
        
        private void OnDashPressed(InputAction.CallbackContext _) => Context.SwitchSubState(Factory.Dash);
        
        private void OnHookPressed(InputAction.CallbackContext _) => Context.SwitchSubState(Factory.HookOut);
    }
}