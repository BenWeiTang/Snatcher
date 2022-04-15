using UnityEngine;

namespace Snatcher
{
    public abstract class ADecision : ScriptableObject
    {
        public abstract bool Decide(EnemyStateMachine context);
    }
}