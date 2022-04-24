using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/Remain State", fileName = "New Remain State")]
    public sealed class EnemyRemainState : AEnemyState
    {
        public override void OnEnterState(EnemyStateMachine context)
        {
            // Strictly no implementation here
        }

        public override void OnExitState(EnemyStateMachine context)
        {
            // Strictly no implementation here
        }
    }
}