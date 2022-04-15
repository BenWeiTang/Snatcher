using System.Collections.Generic;

namespace Snatcher
{
    public class PlayerStateFactory
    {
        private readonly PlayerStateMachine _context;
        
        // Instances of concrete states
        private readonly PlayerGroundedState _grounded;

        public PlayerStateFactory(PlayerStateMachine currentContext)
        {
            _context = currentContext;
            
            // Cache instances of concrete states
            _grounded = new PlayerGroundedState(currentContext, this);
        }
        
        // Declare methods where the return type is the concrete states
        public PlayerGroundedState Grounded() => _grounded;
    }
}
