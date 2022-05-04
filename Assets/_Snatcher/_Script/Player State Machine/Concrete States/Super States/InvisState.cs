using UnityEngine;

namespace Snatcher
{
    public class InvisState : ASuperState
    {
        public sealed override PlayerStateConfig StateConfig { get; protected set; } = StateConfigManager.Instance.InvisStateConfig;
        public sealed override ASubState AbilityEntryState { get; protected set; }
        public sealed override int IsInSuperStateHash { get; protected set; }

        public InvisState(PlayerStateMachine currentContext) : base(currentContext)
        {
            IsInSuperStateHash = Animator.StringToHash("IsInvis");
        }

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            
            base.EnterState();
            AbilityEntryState = Factory.InvisIdle;
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
    }
}