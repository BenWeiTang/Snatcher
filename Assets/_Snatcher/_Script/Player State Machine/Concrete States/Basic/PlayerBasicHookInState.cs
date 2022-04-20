using UnityEngine;

namespace Snatcher
{
    public class PlayerBasicHookInState : APlayerBasicState
    {
        public PlayerBasicHookInState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        public override void EnterState(bool hasSameSuperState)
        {
            if (Context.Debug) this.Log("Enter");
            
            base.EnterState(hasSameSuperState);
            Context.SwitchState(Factory.BasicIdle, true);
        }

        public override void ExitState() { }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
    }
}