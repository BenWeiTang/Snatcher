namespace Snatcher
{
    public class PlayerInvisHookOutState : APlayerInvisState
    {
        public PlayerInvisHookOutState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory)
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