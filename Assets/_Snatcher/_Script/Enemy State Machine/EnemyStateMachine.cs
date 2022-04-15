using UnityEngine;

namespace Snatcher
{
    public class EnemyStateMachine : MonoBehaviour
    {
        /// <summary>
        /// The current state this state machine is in. All the actions and decisions contained in this state will be executed every frame.
        /// </summary>
        public AEnemyState CurrentState { get; private set; }

        [Tooltip("Boilerplate state to conceptualize the idea that transitioning into Remain State is the same as not transitioning into any other state at all.")]
        [SerializeField] private AEnemyState _remainState;

        public void TransitionToState(AEnemyState nextState)
        {
            if (!nextState == _remainState)
            {
                CurrentState.OnExitState(this);
                CurrentState = nextState;
                CurrentState.OnEnterState(this);
            }
        }
        
        private void Update()
        {
            CurrentState.UpdateState(this);
        }
    }
}
