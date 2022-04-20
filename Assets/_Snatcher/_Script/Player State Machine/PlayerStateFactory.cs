namespace Snatcher
{
    public class PlayerStateFactory
    {
        // Instances of concrete states
        public PlayerBasicIdleState BasicIdle { get; }
        public PlayerBasicMoveState BasicMove { get; }
        public PlayerBasicFallState BasicFall { get; }
        public PlayerBasicDashState BasicDash { get; }
        public PlayerBasicHookOutState BasicHookOut { get; }
        public PlayerBasicHookInState BasicHookIn { get; }

        public PlayerStateFactory(PlayerStateMachine currentContext)
        {
            // Cache instances of concrete states
            BasicIdle = new PlayerBasicIdleState(currentContext, this);
            BasicMove = new PlayerBasicMoveState(currentContext, this);
            BasicFall = new PlayerBasicFallState(currentContext, this);
            BasicDash = new PlayerBasicDashState(currentContext, this);
            BasicHookOut = new PlayerBasicHookOutState(currentContext, this);
            BasicHookIn = new PlayerBasicHookInState(currentContext, this);
        }
    }
}
