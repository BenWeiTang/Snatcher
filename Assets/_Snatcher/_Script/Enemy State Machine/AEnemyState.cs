using UnityEngine;

namespace Snatcher
{
    public abstract class AEnemyState : ScriptableObject
    {
        [Tooltip("The action the enemy will do every frame when the enemy is in this state. Note that the order of execution follows the order in the inspector.")]
        [SerializeField] private AEnemyAction[] _actions;
        [Tooltip("The transitions the enemy will check every frame when the enemy is in this state. note that the order of execution follows the order in the inspector.")]
        [SerializeField] private EnemyTransition[] _transitions;
        public abstract void OnEnterState(EnemyStateMachine context);
        public abstract void OnExitState(EnemyStateMachine context);

        public void UpdateState(EnemyStateMachine context)
        {
            DoActions(context);
            CheckTransitions(context);
        }

        private void DoActions(EnemyStateMachine context)
        {
            for (int i = 0; i < _actions.Length; i++)
            {
                _actions[i].Act(context);
            }
        }

        private void CheckTransitions(EnemyStateMachine context)
        {
            for (int i = 0; i < _transitions.Length; i++)
            {
                bool decisionSucceeded = _transitions[i].Decision.Decide(context);
                if (decisionSucceeded)
                {
                    context.TransitionToState(_transitions[i].TrueState);
                }
                else
                {
                    context.TransitionToState(_transitions[i].FalseState);
                }
            }
        }
    }
}