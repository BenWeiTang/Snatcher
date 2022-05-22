using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

namespace Snatcher
{
    public class PropelState : ASubState
    {
        public PropelState(PlayerStateMachine currentContext) : base(currentContext) { }
        private Vector3 _currentDirection;

        private float speed = 1.0f;
        private float propelStateGravity = 9.0f;
        private float flapSpeed = 5.0f;
        private bool isFirstJump;

        Vector3 posOffset = new Vector3 ();

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            isFirstJump = true;
            speed = -flapSpeed;
        }

        public override void ExitState() 
        { 
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
            Debug.Log(FrontGroundCheck(0.1f));
            if (!FrontGroundCheck(0.1f) || isFirstJump) {
                isFirstJump = false;
                return;
            }
            Context.SwitchSubState(Factory.Fall);
        }

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

            Context.Controller.Move(0.5f * (velocity) * Time.deltaTime);
            Context.transform.DOMove(Context.transform.position + Vector3.down * Time.deltaTime * speed, Time.deltaTime);
            speed = speed + propelStateGravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                speed = -flapSpeed;
            }
        }
    }
}
