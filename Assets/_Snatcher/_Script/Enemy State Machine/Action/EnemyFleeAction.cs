using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using UnityEngine;
using UnityEngine.AI;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Action/Flee Action", fileName = "Flee Action")]
    public class EnemyFleeAction : AEnemyAction
    {
        public override void Act(EnemyStateMachine context)
        {
            Flee(context);
        }

        private void Flee(EnemyStateMachine context)
        {
            GameObject Player = GameObject.FindWithTag("Player");
            Vector3 runTo = context.transform.position + ((context.transform.position - Player.transform.position) * 20);
            context.NavMeshAgent.SetDestination(runTo);
        }
    }
}
