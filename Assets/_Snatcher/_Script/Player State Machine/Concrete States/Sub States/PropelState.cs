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
            posOffset = Context.transform.position;
            posOffset.y += 0.1f;
            
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
            if (isFirstJump) {
                if (Context.transform.position.y > posOffset.y) {
                    isFirstJump = false;
                }
                return;
            }
            if (FrontGroundCheck(0.1f)) {
                Context.SwitchSubState(Factory.Idle);
            }
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
            //Context.transform.DOMove(Context.transform.position + Vector3.down * Time.deltaTime * speed, Time.deltaTime);
            Context.transform.position = Context.transform.position + Vector3.down * Time.deltaTime * speed;
            speed = speed + propelStateGravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Debug.Log(isFirstJump);
                LimbManager.Instance.EatLimbStaminaCost();
                speed = -flapSpeed;
            }
        }
    }
}
