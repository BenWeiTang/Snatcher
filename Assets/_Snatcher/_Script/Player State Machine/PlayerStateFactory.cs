namespace Snatcher
{
    public class PlayerStateFactory
    {
        // Instances of concrete states
        // Super states
        public BasicState BasicState { get; }
        public InvisState InvisState { get; }
        
        // Sub states
        public IdleState Idle { get; }
        public MoveState Move { get; }
        public FallState Fall { get; }
        public DashState Dash { get; }
        public HookOutState HookOut { get; }
        public HookInState HookIn { get; }
        public InvisIdleState InvisIdle { get; }

        public PlayerStateFactory(PlayerStateMachine currentContext)
        {
            // Cache instances of concrete states
            // Super states
            BasicState = new BasicState(currentContext, this);
            InvisState = new InvisState(currentContext, this);
            
            // Sub state
            Idle = new IdleState(currentContext, this);
            Move = new MoveState(currentContext, this);
            Fall = new FallState(currentContext, this);
            Dash = new DashState(currentContext, this);
            HookOut = new HookOutState(currentContext, this);
            HookIn = new HookInState(currentContext, this);
            
            // Limb-specific ability states
            InvisIdle = new InvisIdleState(currentContext, this);
        }
    }
}
