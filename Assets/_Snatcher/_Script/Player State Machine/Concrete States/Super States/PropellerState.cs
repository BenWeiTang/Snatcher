using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class PropellerState : ASuperState
    {
        public sealed override PlayerStateConfig StateConfig { get; protected set; } = StateConfigManager.Instance.PropellerStateConfig;
        public sealed override ASubState AbilityEntryState { get; protected set; }

        public PropellerState(PlayerStateMachine currentContext) : base(currentContext) { }

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            
            base.EnterState();
            AbilityEntryState = PlayerStateFactoryManager.Instance.PropellerIdle;
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
    }
}
