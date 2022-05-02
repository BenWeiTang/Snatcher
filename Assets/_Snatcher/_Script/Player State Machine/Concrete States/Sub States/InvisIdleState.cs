using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public class InvisIdleState : ASubState
    {
        public InvisIdleState(PlayerStateMachine currentContext) : base(currentContext) { }

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");

            Context.PlayerInput.Player.UseAbility.performed += OnAbilityPressed;
            
            // This state is the entry state of invis, so we always set animation bool to true here
            Context.Animator.SetBool(SuperState.IsAbilityActiveHash, true);
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
            if (!Context.Controller.isGrounded)
            {
                if (FrontGroundCheck())
                    return;
                Context.SwitchSubState(Factory.Fall);
            }
            
            if (Context.PlayerInput.Player.Movement.ReadValue<Vector2>().sqrMagnitude >= 0.05f)
                Context.SwitchSubState(Factory.InvisMove);
        }
        private void UpdateMovement() => Context.Controller.Move(new Vector3(0f, SuperState.StateConfig.GroundedGravity, 0f) * Time.deltaTime);
        private void OnAbilityPressed(InputAction.CallbackContext _) => Context.SwitchSubState(Factory.Idle);
    }
}