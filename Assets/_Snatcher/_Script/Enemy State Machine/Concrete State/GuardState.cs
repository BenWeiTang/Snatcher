using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Guard State", fileName = "Guard State")]
    public class GuardState : AEnemyState
    {
        public override void OnEnterState(EnemyStateMachine context)
        {
            throw new System.NotImplementedException();
        }

       public override void OnExitState(EnemyStateMachine context)
        {
            throw new System.NotImplementedException();
        }
    }
}
