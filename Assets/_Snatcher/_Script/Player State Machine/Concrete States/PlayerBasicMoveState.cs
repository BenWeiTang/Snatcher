using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public class PlayerBasicMoveState : APlayerBasicState
    {
        public PlayerBasicMoveState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory)
        {
        }

        public override void EnterState(bool hasSameSuperState)
        {
            Debug.Log("Enter Move State");
            
            base.EnterState(hasSameSuperState);
            Context.PlayerInput.Player.Movement.canceled += OnMovementCanceled;
        }

        public override void ExitState()
        {
            Debug.Log("Exit Move State");
            
            Context.PlayerInput.Player.Movement.canceled -= OnMovementCanceled;
        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        protected override void CheckSwitchState()
        {
        }

        private void OnMovementCanceled(InputAction.CallbackContext callbackContext) => Context.SwitchState(Factory.BasicIdle, true);
    }
}