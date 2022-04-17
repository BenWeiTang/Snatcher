namespace Snatcher
{
    public abstract class APlayerBasicState : APlayerState
    {
        protected APlayerBasicState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory)
        {
        }

        public override void EnterState(bool hasSameSuperState)
        {
            if (!hasSameSuperState)
            {
                // Cache a reference to some parameters   
            }
        }
    }
}