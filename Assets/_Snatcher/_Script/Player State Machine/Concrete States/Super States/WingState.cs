using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class WingState : ASuperState
    {
        public sealed override PlayerStateConfig StateConfig { get; protected set; } = StateConfigManager.Instance.WingStateConfig;
        public sealed override ASubState AbilityEntryState { get; protected set; }
        public sealed override int IsInSuperStateHash { get; protected set; }

        public WingState(PlayerStateMachine currentContext) : base(currentContext) 
        {
            IsInSuperStateHash = Animator.StringToHash("IsWing");
        }

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            
            base.EnterState();
            AbilityEntryState = PlayerStateFactoryManager.Instance.Propel;
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
    }
}
