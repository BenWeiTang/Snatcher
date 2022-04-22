using UnityEngine;

namespace Snatcher
{
    public abstract class ASuperState : APlayerState
    {
        protected ASuperState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory)
        {
        }

        public abstract PlayerStateConfig StateConfig { get; set; }
        public abstract ASubState AbilityEntryState { get; protected set; }
        public abstract int IsMovingHash { get; protected set; }
        public abstract int IsFallingHash { get; protected set; }
        public abstract int IsThrowingHash { get; protected set; }
    }
}
