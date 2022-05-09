using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class PropellerIdleState : ASubState
    {

        public PropellerIdleState(PlayerStateMachine currentContext) : base(currentContext) { }
        public override void EnterState()
        {
            if (Context.Debug) this.Log("Enter");

            Context.Animator.SetBool(SuperState.IsAbilityActiveHash, true);
        }

        public override void ExitState() { }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }
    }
}
