using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace Snatcher
{
    
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/State/Invis Guard State", fileName = "Invis Guard State")]
    public class EnemyInvisGuardState : AEnemyState
    {
        public override void OnEnterState(EnemyStateMachine context)
        {
            //context.MaterialRenderer.material = context.EnemyInvisMaterial;
        }

        public override void OnExitState(EnemyStateMachine context)
        {
            
        }
    }
}
