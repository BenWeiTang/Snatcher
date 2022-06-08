using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/State/Chase State", fileName = "Enemy Chase State")]
    public class ChaseState : AEnemyState
    {
        public override void OnEnterState(EnemyStateMachine context)
        {
            context.Animator.SetBool("Moving", true);
        }

        public override void OnExitState(EnemyStateMachine context)
        {
        }
    }
}
