using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Enemy State Machine/State/Guard State", fileName = "Guard State")]
    public class GuardState : AEnemyState
    {
        public override void OnEnterState(EnemyStateMachine context)
        {
            context.Animator.SetBool("Moving", false);
        }

       public override void OnExitState(EnemyStateMachine context)
        {
        }
    }
}
