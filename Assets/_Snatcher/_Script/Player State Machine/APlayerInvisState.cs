namespace Snatcher
{
    public abstract class APlayerInvisState : APlayerState
    {
        protected override PlayerStateConfig StateConfig { get; } = StateConfigManager.Instance.InvisStateConfig;
        protected APlayerInvisState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        public override void EnterState(bool hasSameSuperState)
        {
            if (!hasSameSuperState)
            {
                // Put initialization-related code here, if entering from a state whose super state isn't this state
                // For example,if we are entering from a different state family, we want to swap the limb for our character
            }
        }
    }
}