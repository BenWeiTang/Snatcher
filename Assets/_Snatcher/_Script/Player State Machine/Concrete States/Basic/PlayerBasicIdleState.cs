﻿using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public class PlayerBasicIdleState : APlayerBasicState
    {
        public PlayerBasicIdleState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        public override void EnterState(bool hasSameSuperState)
        {
            if (Context.Debug) Debug.Log("");
            
            base.EnterState(hasSameSuperState);
            
            // Subscribe to the started event on Dash
            Context.PlayerInput.Player.Dash.started += OnDashPressed;
            // Subscribe to the started event on Hook/Snatch
            Context.PlayerInput.Player.Snatch.started += OnHookPressed;
        }


        public override void ExitState()
        {
            // IMPORTANT!!! Make sure you unsubscribe from the event when exiting this state
            Context.PlayerInput.Player.Dash.started -= OnDashPressed;
            Context.PlayerInput.Player.Snatch.started -= OnHookPressed;
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
            {
                if (FrontGroundCheck()) 
                    return;
                Context.SwitchState(Factory.BasicFall, true);
            }
            
            if (Context.PlayerInput.Player.Movement.ReadValue<Vector2>().sqrMagnitude >= 0.05f)
                Context.SwitchState(Factory.BasicMove, true);
        }

        private void UpdateMovement() => Context.Controller.Move(new Vector3(0f, StateConfig.GroundedGravity, 0f) * Time.deltaTime);

        private void OnDashPressed(InputAction.CallbackContext _) => Context.SwitchState(Factory.BasicDash, true);

        private void OnHookPressed(InputAction.CallbackContext _) => Context.SwitchState(Factory.BasicHookOut, true);
    }
}