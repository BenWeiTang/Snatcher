namespace Snatcher
{
    public class PlayerInvisActiveIdleState : APlayerInvisState
    {
        //README and delete later
        // I'm not too sure how you want to implement the ability state(s)
        // Looking at week 2's demo, I think there should be two states where the invi ability is active
        // The Invis Idle state when pressing down left control, and
        // the the Invis Move state when moving while pressing down left control
        // You might not want to press down left control and alternatively use something like a toggle 
        // I think that is also doable
        public PlayerInvisActiveIdleState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory)
        {
        }

        public override void EnterState(bool hasSameSuperState)
        {
            if (Context.Debug) this.Log("Enter");
            base.EnterState(hasSameSuperState);
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
        }

        protected override void CheckSwitchState()
        {
        }
    }
}