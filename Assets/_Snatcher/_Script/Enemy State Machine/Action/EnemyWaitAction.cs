using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Action/Wait Action", fileName = "WaitAction")]
    public class EnemyWaitAction : AEnemyAction
    {
        public override void Act(EnemyStateMachine context)
        {
            Wait(context);
        }

        private void Wait(EnemyStateMachine context)
        {
            context.NavMeshAgent.isStopped = true;
        }
    }
}
