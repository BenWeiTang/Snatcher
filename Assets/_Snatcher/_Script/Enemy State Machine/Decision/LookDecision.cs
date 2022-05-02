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
           RaycastHit hitInfo;
           
           Debug.DrawRay(context.transform.position, context.transform.forward.normalized * context.EnemyLookDistance, Color.green );
           
           if (Physics.SphereCast(context.transform.position + 0.5f * Vector3.up, 1.0f, context.transform.forward.normalized, out hitInfo,
                   context.EnemyLookDistance) && hitInfo.collider.CompareTag("Player"))
           {
               context.ChaseTarget = hitInfo.transform;
               return true;
           }

           return false;
       }
    }
}
