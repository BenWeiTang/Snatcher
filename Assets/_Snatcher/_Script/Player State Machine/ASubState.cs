namespace Snatcher
{
    public abstract class ASubState : APlayerState
    {
        protected ASubState(PlayerStateMachine currentContext) : base(currentContext) { }

        protected ASuperState SuperState => Context.CurrentSuperState;
    }
}