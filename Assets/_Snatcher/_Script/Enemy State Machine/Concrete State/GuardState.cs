using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Guard State", fileName = "Guard State")]
    public class GuardState : AEnemyState
    {
        public override void OnEnterState(EnemyStateMachine context)
        {
        }

       public override void OnExitState(EnemyStateMachine context)
        {
        }
    }
}
