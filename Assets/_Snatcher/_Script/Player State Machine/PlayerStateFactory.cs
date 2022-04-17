using System.Collections.Generic;

namespace Snatcher
{
    public class PlayerStateFactory
    {
        // Instances of concrete states
        public PlayerBasicIdleState BasicIdle { get; }
        public PlayerBasicMoveState BasicMove { get; }

        public PlayerStateFactory(PlayerStateMachine currentContext)
        {
            // Cache instances of concrete states
            BasicIdle = new PlayerBasicIdleState(currentContext, this);
            BasicMove = new PlayerBasicMoveState(currentContext, this);
        }
    }
}
