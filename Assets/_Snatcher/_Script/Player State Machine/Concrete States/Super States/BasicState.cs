﻿using UnityEngine;

namespace Snatcher
{
    public class BasicState : ASuperState
    {
        public sealed override PlayerStateConfig StateConfig { get; protected set; } = StateConfigManager.Instance.BasicStateConfig;
        public sealed override ASubState AbilityEntryState { get; protected set; }
        public sealed override int IsInSuperStateHash { get; protected set; }

        public BasicState(PlayerStateMachine currentContext) : base(currentContext)
        {
            IsInSuperStateHash = Animator.StringToHash("IsBasic");
        }

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            
            base.EnterState();
            AbilityEntryState = Factory.HookOut;
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
    }
}