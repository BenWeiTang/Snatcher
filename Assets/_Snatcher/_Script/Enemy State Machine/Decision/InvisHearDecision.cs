using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Decision/Hear Decision", fileName = "HearDecision")]
    public class InvisHearDecision : ADecision
    {
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
                if (hitCollider.tag == "Player")
                {
                    context.ChaseTarget = hitCollider.transform;
                    return true;
                }
            }

            return false;
        }
    }
}
