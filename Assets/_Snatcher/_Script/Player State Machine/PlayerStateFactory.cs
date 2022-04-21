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
        public PlayerInvisIdleState InvisIdle { get; }
        public PlayerInvisMoveState InvisMove { get; }
        public PlayerInvisFallState InvisFall { get; }
        public PlayerInvisDashState InvisDash { get; }
        public PlayerInvisHookOutState InvisHookOut { get; }
        public PlayerInvisHookInState InvisHookIn { get; }
        public PlayerInvisActiveIdleState InvisActiveIdle { get; }
        public PlayerInvisActiveMoveState InvisActiveMove { get; }

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
            InvisIdle = new PlayerInvisIdleState(currentContext, this);
            InvisMove = new PlayerInvisMoveState(currentContext, this);
            InvisFall = new PlayerInvisFallState(currentContext, this);
            InvisDash = new PlayerInvisDashState(currentContext, this);
            InvisHookOut = new PlayerInvisHookOutState(currentContext, this);
            InvisHookIn = new PlayerInvisHookInState(currentContext, this);
            InvisActiveIdle = new PlayerInvisActiveIdleState(currentContext, this);
            InvisActiveMove = new PlayerInvisActiveMoveState(currentContext, this);
        }
    }
}
