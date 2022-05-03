using System.Linq;
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


        // Gets the renderer of the invis and selects the two materials the enemy should swap between during invis and non-invis states
        public SkinnedMeshRenderer MaterialRenderer;
        public Material EnemyInvisMaterial;
        public Material EnemyDefaultMaterial;

        // Sets if this Enemy has an ability and what state should the enemy go to when the ability is stolen
        public bool hasAbility = true;
        public AEnemyState StolenState;

        //Enemy patrol behavior
        // The points the enemy should patrol between
        public Transform[] PatrolPoints;
        [HideInInspector] public int destinationPointIndex = 0;

        public void TransitionToState(AEnemyState nextState)
        {
            if (nextState != _remainState)
            {
                CurrentState.OnExitState(this);
                CurrentState = nextState;
                CurrentState.OnEnterState(this);
            }
        }

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.isStopped = true;
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
        
        public void AbilityStolen()
        {
            if (hasAbility)
            {
                CurrentState = StolenState;
            }
        }
    }
}