namespace Snatcher
{
    public abstract class APlayerState
    {
        protected PlayerStateMachine Context => _context;
        protected PlayerStateFactory Factory => _factory;
        protected abstract PlayerStateConfig StateConfig { get; }

        private readonly PlayerStateMachine _context;
        private readonly PlayerStateFactory _factory;

        protected APlayerState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory)
        {
            _context = currentContext;
            _factory = currentFactory;
        }

        public abstract void EnterState(bool hasSameSuperState);
        public abstract void ExitState();
        public abstract void UpdateState();
        protected abstract void CheckSwitchState();
    }
}