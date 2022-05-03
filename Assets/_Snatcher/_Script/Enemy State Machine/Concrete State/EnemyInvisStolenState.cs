using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/State/Invis Stolen State", fileName = "Invis Stolen State")]
    public class EnemyInvisStolenState : AEnemyState
    {
        public override void OnEnterState(EnemyStateMachine context)
        {
            context.MaterialRenderer.material = context.EnemyDefaultMaterial;
        }

        public override void OnExitState(EnemyStateMachine context)
        {
            
        }
    }
}
