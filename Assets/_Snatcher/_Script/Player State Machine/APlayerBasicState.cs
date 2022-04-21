namespace Snatcher
{
    public abstract class APlayerBasicState : APlayerState
    {
        // A getter for all the child classes (sub states) to get access to the State Config
        // that only concerns the configurations for this state
        // For the sub states, just call "StateConfig" to access the data.
        protected override PlayerStateConfig StateConfig { get; } = StateConfigManager.Instance.BasicStateConfig;
        
        protected APlayerBasicState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

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