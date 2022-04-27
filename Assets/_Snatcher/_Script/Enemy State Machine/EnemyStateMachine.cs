using UnityEngine;
using UnityEngine.AI;

namespace Snatcher
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyStateMachine : MonoBehaviour
    {
        public AEnemyState CurrentState { get; private set; }
        public NavMeshAgent NavMeshAgent => _agent;
        public Animator Animator => _animator;
        public Transform ChaseTarget { get; set; }
        public float EnemyLookDistance => _enemyLookDistance.Value;

        [Tooltip("Boilerplate state to conceptualize the idea that transitioning into Remain State is the same as not transitioning into any other state at all.")]
        [SerializeField] private AEnemyState _remainState;
        [Tooltip("The first state the enemy will start with. For example, in the beginning of a level, the enemy may be in idle or on patrol.")]
        [SerializeField] private AEnemyState _defaultState;
        [SerializeField] private Animator _animator;
        [SerializeField] private FloatReference _enemyLookDistance;
        private NavMeshAgent _agent;

        public void TransitionToState(AEnemyState nextState)
        {
            if (!nextState == _remainState)
            {
                CurrentState.OnExitState(this);
                CurrentState = nextState;
                CurrentState.OnEnterState(this);
            }
        }

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            CurrentState = _defaultState;
            CurrentState.OnEnterState(this);
        }

        private void Update()
        {
            CurrentState.UpdateState(this);
        }
    }
}