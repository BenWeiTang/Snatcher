using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Remain State", fileName = "New Remain State")]
    public class EnemyRemainState : AEnemyState
    {
        public override void OnEnterState(EnemyStateMachine context)
        {
        }

        public override void OnExitState(EnemyStateMachine context)
        {
        }
    }
}