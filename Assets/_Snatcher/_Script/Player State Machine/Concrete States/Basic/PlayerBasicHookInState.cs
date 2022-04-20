using UnityEngine;

namespace Snatcher
{
    public class PlayerBasicHookInState : APlayerBasicState
    {
        public PlayerBasicHookInState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory)
        {
        }

        public override void EnterState(bool hasSameSuperState)
        {
            Debug.Log("Hook in");
            base.EnterState(hasSameSuperState);
            Context.SwitchState(Factory.BasicIdle, true);
        }

        public override void ExitState() { }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
    }
}