using UnityEngine;

namespace Snatcher
{
    
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Decision/Look Decision", fileName = "LookDecision")]
    public class LookDecision : ADecision
    {
        [SerializeField] private PlayerStateReference _currentPlayerSubState;
        [SerializeField] private FloatReference _viewAngleRef;
        
        private Transform _target;
        
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
                if(hitCollider.CompareTag("Player"))
                {
                    //Check if player is invisible
                    var currentType = _currentPlayerSubState.Value.GetType();
                    if (currentType == typeof(InvisIdleState) || currentType == typeof(InvisMoveState))
                    {
                        return false;
                    }
                    

                    _target = hitCollider.transform;
                    
                    Vector3 directionToTarget = (_target.position - context.transform.position).normalized;
                    if (Vector3.Angle(context.transform.forward, directionToTarget) <= _viewAngleRef.Value)
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
