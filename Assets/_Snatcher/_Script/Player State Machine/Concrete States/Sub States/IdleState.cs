using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public class IdleState : ASubState
    {
        public IdleState(PlayerStateMachine currentContext) : base(currentContext) { }


        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            
            Context.PlayerInput.Player.Dash.started += OnDashPressed;
            Context.PlayerInput.Player.UseAbility.started += OnAbilityPressed;
        }

        public override void ExitState()
        {
            Context.PlayerInput.Player.Dash.started -= OnDashPressed;
            Context.PlayerInput.Player.UseAbility.started -= OnAbilityPressed;
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
                Context.SwitchSubState(Factory.Move);
        }
        
        private void UpdateMovement() => Context.Controller.Move(new Vector3(0f, SuperState.StateConfig.GroundedGravity, 0f) * Time.deltaTime);
        private void OnDashPressed(InputAction.CallbackContext _) => Context.SwitchSubState(Factory.Dash);
        private void OnAbilityPressed(InputAction.CallbackContext _) => Context.SwitchSubState(SuperState.AbilityEntryState);
    }
}