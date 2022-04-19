using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Snatcher
{
    public class PlayerBasicHookInState : APlayerBasicState
    {
        public PlayerBasicHookInState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory)
        {
        }

        public override void EnterState(bool hasSameSuperState)
        {
            base.EnterState(hasSameSuperState);
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
        }

        protected override void CheckSwitchState()
        {
        }
    }
}