using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Chase State", fileName = "Enemy Chase State")]
    public class ChaseState : AEnemyState
    {
        public override void OnEnterState(EnemyStateMachine context)
        {
            UpdateState(context);
        }

        public override void OnExitState(EnemyStateMachine context)
        {
            UpdateState(context);
        }
    }
}
