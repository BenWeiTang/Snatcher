using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Decision/Despawn Decision", fileName = "Despawn Decision")]
    public class EnemyDespawnDecision : ADecision
    {
        public override bool Decide(EnemyStateMachine context)
        {
            return Despawn(context);
        }

        private bool Despawn(EnemyStateMachine context)
        {
            GameObject Player = GameObject.FindWithTag("Player");
            if (Vector3.Distance(context.transform.position, Player.transform.position) > 10)
            {
                Destroy(context);
            }

            return false;
        }
    }
}
