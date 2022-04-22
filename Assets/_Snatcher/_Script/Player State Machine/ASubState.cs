using UnityEngine;

namespace Snatcher
{
    public abstract class ASubState : APlayerState
    {
        protected ASubState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        protected ASuperState SuperState => Context.CurrentSuperState;
    }
}
