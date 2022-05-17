using UnityEngine;

namespace Snatcher
{
    public class LegState : ASuperState
    {
        public sealed override PlayerStateConfig StateConfig { get; protected set; } = StateConfigManager.Instance.LegStateConfig;
        public sealed override ASubState AbilityEntryState { get; protected set; }
        
        public LegState(PlayerStateMachine currentContext) : base(currentContext) { }

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            
            base.EnterState();
            AbilityEntryState = PlayerStateFactoryManager.Instance.Vault;
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
    }
}
