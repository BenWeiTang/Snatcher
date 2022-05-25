using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public class PropellerIdleState : ASubState
    {

        public PropellerIdleState(PlayerStateMachine currentContext) : base(currentContext) { }
        public float amplitude = 0.5f;
        public float frequency = 0.5f;

        Vector3 posOffset = new Vector3 ();
        Vector3 tempPos = new Vector3 ();

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            Context.PlayerInput.Player.UseAbility.performed += OnAbilityPressed;
            Context.Animator.SetBool(SuperState.IsAbilityActiveHash, true);

            
            posOffset = Context.transform.position;
            posOffset.y += 3f;
        }

        public override void ExitState() 
        { 
            Context.PlayerInput.Player.UseAbility.performed -= OnAbilityPressed;
        }

        public override void UpdateState() 
        { 
            UpdateMovement();
            CheckSwitchState();
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
            
            if (Context.PlayerInput.Player.Movement.ReadValue<Vector2>().sqrMagnitude >= 0.05f)
                Context.SwitchSubState(Factory.PropellerMove);
        }

        //Float up and down
        private void UpdateMovement() 
        {
            tempPos = posOffset;
            tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
            Context.transform.position = tempPos;
        }
        private void OnAbilityPressed(InputAction.CallbackContext _) => Context.SwitchSubState(Factory.Idle);
    }
}
