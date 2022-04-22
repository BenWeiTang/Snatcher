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
        public HookOut HookOut { get; }
        public HookIn HookIn { get; }
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
            HookOut = new HookOut(currentContext, this);
            HookIn = new HookIn(currentContext, this);
            
            // Limb-specific ability states
            InvisIdle = new InvisIdleState(currentContext, this);
        }
    }
}
