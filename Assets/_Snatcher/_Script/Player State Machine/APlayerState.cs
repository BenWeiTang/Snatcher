using UnityEngine;

namespace Snatcher
{
    public abstract class APlayerState
    {
        protected PlayerStateMachine Context => _context;
        protected PlayerStateFactory Factory => _factory;

        private readonly PlayerStateMachine _context;
        private readonly PlayerStateFactory _factory;

        protected APlayerState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory)
        {
            _context = currentContext;
            _factory = currentFactory;
        }

        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
        protected abstract void CheckSwitchState();
        
        /// <summary>
        /// Cast a downward ray from the character's toe for a distance to do a raycast check.
        /// </summary>
        /// <param name="maxDistance">The distance the ray will travel for the raycast check</param>
        /// <returns></returns>
        protected virtual bool FrontGroundCheck(float maxDistance = 0.5f)
        {
            return Physics.Raycast(Context.GroundCheck.position, Vector3.down, maxDistance);
        }
    }
}