using UnityEngine;

namespace Snatcher
{
    
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Decision/Look Decision", fileName = "LookDecision")]
    public class LookDecision : ADecision
    {
        private float angle = 60.0f;
        private Transform target;
        
        public override bool Decide(EnemyStateMachine context)
       {
           bool targetVisible = Look(context);
           return targetVisible;
       }

       private bool Look(EnemyStateMachine context)
       {
           RaycastHit hitInfo;
           
           Debug.DrawRay(context.transform.position, context.transform.forward.normalized * context.EnemyLookDistance, Color.green );

            Collider[] hitColliders = Physics.OverlapSphere(context.transform.position, context.EnemyLookDistance);
            foreach (var hitCollider in hitColliders)
            {
                if(hitCollider.tag == "Player")
                {
                    //Check if player is invisible
                    ASuperState playerState = NonPlayerPlayerStateReference.Instance.CurrentState;
                    if (playerState.GetType() == typeof(InvisState))
                    {
                        return false;
                    }



                    target = hitCollider.transform;
                    
                    Vector3 directionToTarget = (target.position - context.transform.position).normalized;
                    if (Vector3.Angle(context.transform.forward, directionToTarget) <= angle)
                    {
                        if (Physics.Raycast(context.transform.position + Vector3.up * 1f, directionToTarget,out hitInfo, context.EnemyLookDistance))
                        {
                            if (hitInfo.collider.CompareTag("Player"))
                            {
                                context.ChaseTarget = hitCollider.transform;
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
       }
    }
}
