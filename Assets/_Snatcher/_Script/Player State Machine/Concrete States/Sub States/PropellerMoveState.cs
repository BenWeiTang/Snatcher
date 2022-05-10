using UnityEngine;
using UnityEngine.InputSystem;


namespace Snatcher
{
    public class PropellerMoveState : ASubState
    {
        public PropellerMoveState(PlayerStateMachine currentContext) : base(currentContext) { }
        private Vector3 _currentDirection;
        public float amplitude = 0.5f;
        public float frequency = 0.5f;

        Vector3 posOffset = new Vector3 ();
        Vector3 tempPos = new Vector3 ();

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            posOffset = Context.transform.position;
            //posOffset.y += 3f;
            //Context.PlayerInput.Player.Movement.canceled += OnMovementCanceled;
            Context.PlayerInput.Player.UseAbility.performed += OnAbilityPressed;
            Context.Animator.SetBool(SuperState.IsMovingHash, true);
        }

        public override void ExitState() 
        { 
            Context.PlayerInput.Player.UseAbility.performed -= OnAbilityPressed;
            //Context.PlayerInput.Player.Movement.canceled -= OnMovementCanceled;
            Context.Animator.SetBool(SuperState.IsMovingHash, false);
        }

        public override void UpdateState() 
        { 
            UpdateDirection();
            UpdateRotation();
            UpdateMovement();
            //CheckSwitchState();
        }

        protected override void CheckSwitchState() 
        { 
            /*
            if (!Context.Controller.isGrounded)
            {
                if (FrontGroundCheck())
                    return;
                Context.SwitchSubState(Factory.Fall);
            }
            */
        }

        private void UpdateDirection()
        {
            Vector2 currentInput = Context.PlayerInput.Player.Movement.ReadValue<Vector2>();
            _currentDirection.x = currentInput.x;
            _currentDirection.z = currentInput.y;
            _currentDirection = _currentDirection.ToIso();
        }
        private void UpdateMovement() 
        {
            tempPos = posOffset;
            tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
            Context.transform.position = tempPos;

            
            Vector3 velocity = _currentDirection;
            velocity *= SuperState.StateConfig.MoveSpeed;
            //velocity.y = SuperState.StateConfig.GroundedGravity;
            //velocity.y = tempPos.y;
            
            //TODO: make the speed reduction configurable
            Context.Controller.Move(0.5f * (velocity) * Time.deltaTime);
            
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

        private void OnMovementCanceled(InputAction.CallbackContext callbackContext) => Context.SwitchSubState(Factory.PropellerIdle);
        private void OnAbilityPressed(InputAction.CallbackContext _) => Context.SwitchSubState(Factory.Idle);
    }
}
