using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public class PlayerBasicIdleState : APlayerBasicState
    {
        public PlayerBasicIdleState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        public override void EnterState(bool hasSameSuperState)
        {
            base.EnterState(hasSameSuperState);
        }

        public override void ExitState()
        {
            // IMPORTANT!!! Make sure you unsubscribe from the event when exiting this state
        }

        public override void UpdateState()
        {
            UpdateMovement();
            CheckSwitchState();
        }

        // CheckSwitchState should ONLY be called in the UpdateState method
        protected override void CheckSwitchState()
        {
            if (!Context.Controller.isGrounded)
                Context.SwitchState(Factory.BasicFall, true);
            
            if (Context.PlayerInput.Player.Movement.ReadValue<Vector2>().sqrMagnitude >= 0.05f)
                Context.SwitchState(Factory.BasicMove, true);
        }

        private void UpdateMovement() => Context.Controller.Move(new Vector3(0f, StateConfig.GroundedGravity, 0f) * Time.deltaTime);
    }
}