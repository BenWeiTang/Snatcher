using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Chase State", fileName = "Enemy Chase State")]
    public class ChaseState : AEnemyState
    {
        public override void OnEnterState(EnemyStateMachine context)
        {
        }

        public override void OnExitState(EnemyStateMachine context)
        {
        }
    }
}
