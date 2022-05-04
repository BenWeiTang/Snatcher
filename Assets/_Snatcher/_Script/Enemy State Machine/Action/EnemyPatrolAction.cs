using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Action/Patrol Action", fileName = "Patrol Action")]
    public class EnemyPatrolAction : AEnemyAction
    {
       public override void Act(EnemyStateMachine context)
        {
            Patrol(context);
        }

       private void Patrol(EnemyStateMachine context)
       {
           if (!context.NavMeshAgent.pathPending)
           {
               context.NavMeshAgent.destination = context.PatrolPoints[context.destinationPointIndex].position;
               if (!context.NavMeshAgent.pathPending && context.NavMeshAgent.remainingDistance == 0f)
               {
                   GoToNextPoint(context);
               }
               context.NavMeshAgent.isStopped = false;
           }
       }

       private void GoToNextPoint(EnemyStateMachine context)
       {
           context.destinationPointIndex = (context.destinationPointIndex + 1) % context.PatrolPoints.Length;
           context.NavMeshAgent.destination = context.PatrolPoints[context.destinationPointIndex].position;
       }
    }
}
