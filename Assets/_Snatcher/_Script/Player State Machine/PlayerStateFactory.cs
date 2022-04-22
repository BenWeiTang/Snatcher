namespace Snatcher
{
    public class PlayerStateFactory
    {
        // Instances of concrete states
        // Basic states
        public PlayerBasicIdleState BasicIdle { get; }
        public PlayerBasicMoveState BasicMove { get; }
        public PlayerBasicFallState BasicFall { get; }
        public PlayerBasicDashState BasicDash { get; }
        public PlayerBasicHookOutState BasicHookOut { get; }
        public PlayerBasicHookInState BasicHookIn { get; }
        
        // Invisibility states
        public PlayerInvisActiveIdleState InvisActiveIdle { get; }
        public PlayerInvisActiveMoveState InvisActiveMove { get; }
        
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
            // Basic states
            BasicIdle = new PlayerBasicIdleState(currentContext, this);
            BasicMove = new PlayerBasicMoveState(currentContext, this);
            BasicFall = new PlayerBasicFallState(currentContext, this);
            BasicDash = new PlayerBasicDashState(currentContext, this);
            BasicHookOut = new PlayerBasicHookOutState(currentContext, this);
            BasicHookIn = new PlayerBasicHookInState(currentContext, this);
            
            // Invisibility states
            InvisActiveIdle = new PlayerInvisActiveIdleState(currentContext, this);
            InvisActiveMove = new PlayerInvisActiveMoveState(currentContext, this);
            
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
