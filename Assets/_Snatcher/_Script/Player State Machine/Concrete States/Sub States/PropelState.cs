using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

namespace Snatcher
{
    public class PropelState : ASubState
    {
        public PropelState(PlayerStateMachine currentContext) : base(currentContext) { }
        private Vector3 _currentDirection;
        private float _speed = 1.0f;
        private float _propelStateGravity = 9.0f;
        private float _flapSpeed = 6.0f;
        private float _propelStateGroundCheckValue = 0.25f;
        private bool _isFirstJump;
        private bool _ateFirstJumpStamina;

        Vector3 posOffset = new Vector3 ();

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            posOffset = Context.transform.position;
            posOffset.y += _propelStateGroundCheckValue;
            
            _isFirstJump = true;
            _ateFirstJumpStamina = false;

            if(LimbManager.Instance.CurrentLimb.StaminaCost > LimbManager.Instance.CurrentStamina) 
                return;
            _speed = -_flapSpeed;
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
            if (_isFirstJump) 
            {
                if (Context.transform.position.y > posOffset.y) 
                    _isFirstJump = false;

                if(LimbManager.Instance.CurrentLimb.StaminaCost > LimbManager.Instance.CurrentStamina && !_ateFirstJumpStamina) 
                    Context.SwitchSubState(Factory.Idle);

                return;
            }

            if (FrontGroundCheck(_propelStateGroundCheckValue)) 
                Context.SwitchSubState(Factory.Idle);
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

            //Moves the player along the y axis
            Context.transform.position = Context.transform.position + Vector3.down * Time.deltaTime * _speed;
            _speed = _speed + _propelStateGravity * Time.deltaTime;

            //TODO: use the new input system with callbacks; talk to ben for detail
            //TODO: separate the logics in a different method
            if (Input.GetKeyDown(KeyCode.Mouse0)) 
            {
                if (LimbManager.Instance.EatLimbStaminaCost())
                {
                    _ateFirstJumpStamina = true;
                    _speed = -_flapSpeed;
                }
            }
        }
    }
}
