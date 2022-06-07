using UnityEngine;

namespace Snatcher
{
    
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Decision/Hear Decision", fileName = "HearDecision")]
    public class InvisHearDecision : ADecision
    {
        [SerializeField] private PlayerStateReference _currentPlayerSubState;
        public override bool Decide(EnemyStateMachine context)
        {
            bool targetVisible = Hear(context);
            return targetVisible;
        }

        private bool Hear(EnemyStateMachine context)
        {
            Collider[] hitColliders = Physics.OverlapSphere(context.transform.position, context.EnemyLookDistance);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Player"))
                {
                    var currentType = _currentPlayerSubState.Value.GetType();
                    if (currentType == typeof(InvisIdleState) || currentType == typeof(InvisMoveState))
                    {
                        context.ChaseTarget = hitCollider.transform;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
