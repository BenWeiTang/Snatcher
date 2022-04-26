using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using UnityEngine;

namespace Snatcher
{
    
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Decision/Look Decision", fileName = "LookDecision")]
    public class LookDecision : ADecision
    {
        public override bool Decide(EnemyStateMachine context)
       {
           bool targetVisible = Look(context);
           return targetVisible;
       }

       private bool Look(EnemyStateMachine context)
       {
           if (Physics.SphereCast(context.transform.position, 5.0f, context.transform.forward, out RaycastHit hitInfo,
                   context.EnemyLookDistance) && hitInfo.collider.CompareTag("Player"))
           {
               context.ChaseTarget = hitInfo.transform;
               return true;
           }
           else
           {
               return false;
           }
       }
    }
}
