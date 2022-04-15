using UnityEngine;

namespace Snatcher
{
    public abstract class AEnemyAction : ScriptableObject
    {
        public abstract void Act(EnemyStateMachine context);
    }
}