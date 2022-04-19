namespace Snatcher
{
    public abstract class APlayerBasicState : APlayerState
    {
        protected PlayerStateConfig StateConfig
        {
            get
            {
                if (_stateConfig == null)
                    _stateConfig = StateConfigManager.Instance.BasicStateConfig;
                return _stateConfig;
            }
        }
        
        private PlayerStateConfig _stateConfig;

        protected APlayerBasicState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        public override void EnterState(bool hasSameSuperState)
        {
            if (!hasSameSuperState)
            {
                // Put initialization-related code here, if entering from a state whose super state isn't this state
            }
        }
    }
}