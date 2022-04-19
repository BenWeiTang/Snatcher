using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Snatcher
{
    public class PlayerBasicHookOutState : APlayerBasicState
    {
        public PlayerBasicHookOutState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory) { }

        public override void EnterState(bool hasSameSuperState)
        {
        }

        public override void ExitState() { }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
    }
}