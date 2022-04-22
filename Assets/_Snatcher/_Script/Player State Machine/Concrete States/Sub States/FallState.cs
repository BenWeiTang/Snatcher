using UnityEngine;

namespace Snatcher
{
    public class FallState : ASubState
    {
        private Vector3 _currentDirection;
        
        public FallState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            
            Context.Animator.SetBool(SuperState.IsFallingHash, true);
            // Context.Controller.Move(0.2f * Context.transform.forward);
        }

        public override void ExitState()
        {
            Context.Animator.SetBool(SuperState.IsFallingHash,false);
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
            if (Context.Controller.isGrounded)
                Context.SwitchSubState(Factory.Idle);
        }
        
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
            positionToLookAt.y = 0f;
            
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
            velocity.y += Context.Controller.velocity.y + SuperState.StateConfig.AirborneGravity;
            velocity.y = Mathf.Max(velocity.y, -SuperState.StateConfig.MaxFallSpeed);
            
            Context.Controller.Move(velocity * Time.deltaTime);
        }
    }
}