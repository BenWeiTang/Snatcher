using UnityEngine;

namespace Snatcher
{
    public abstract class AEnemyState : ScriptableObject
    {
        [Tooltip("The action the enemy will do every frame when the enemy is in this state. Note that the order of execution follows the order in the inspector.")]
        [SerializeField] private AEnemyAction[] _actions;
        [Tooltip("The transitions the enemy will check every frame when the enemy is in this state. note that the order of execution follows the order in the inspector.")]
        [SerializeField] private EnemyTransition[] _transitions;
        
        /// <summary>
        /// This method is called whenever the context enters this state. If you rely on event(s) in the context to exit this state, this is where you subscribe.
        /// </summary>
        /// <param name="context">The Enemy State Machine that will use this state to perform actions</param>
        public abstract void OnEnterState(EnemyStateMachine context);
        
        /// <summary>
        /// This method is called whenever the context exits this state. If you previously subscribed to event(s) in the context, you must unsubscribe from it/them here.
        /// </summary>
        /// <param name="context">The Enemy State Machine that used this state to perform perform actions</param>
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