﻿namespace Snatcher
{
    public class HookInState : ASubState
    {
        public HookInState(PlayerStateMachine currentContext) : base(currentContext) { }

        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            
            Context.SwitchSubState(Factory.Idle);
        }

        public override void ExitState()
        {
            Context.Animator.SetBool(SuperState.IsThrowingHash, false);
        }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
    }
}