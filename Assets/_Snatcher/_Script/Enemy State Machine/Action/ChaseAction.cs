using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Action/Chase Action", fileName = "ChaseAction")]
    public class ChaseAction : AEnemyAction
    {
        public override void Act(EnemyStateMachine context)
        {
            Chase(context);
        }

        private void Chase(EnemyStateMachine context)
        {
            context.NavMeshAgent.destination = context.ChaseTarget.position;
            context.NavMeshAgent.Resume();
        }
    }
}
