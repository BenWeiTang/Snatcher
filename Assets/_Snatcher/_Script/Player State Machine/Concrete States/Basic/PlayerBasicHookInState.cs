using UnityEngine;

namespace Snatcher
{
    public class PlayerBasicHookInState : APlayerBasicState
    {
        private readonly int _isThrowingHash;

        public PlayerBasicHookInState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory)
        {
            _isThrowingHash = Animator.StringToHash("IsThrowing");
        }

        public override void EnterState(bool hasSameSuperState)
        {
            if (Context.Debug) this.Log("Enter");
            
            base.EnterState(hasSameSuperState);
            Context.SwitchState(Factory.BasicIdle, true);
        }

        public override void ExitState()
        {
            Context.Animator.SetBool(_isThrowingHash, false);
        }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
    }
}