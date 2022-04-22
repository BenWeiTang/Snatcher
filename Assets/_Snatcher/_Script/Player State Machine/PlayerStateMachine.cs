using UnityEngine;

namespace Snatcher
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerStateMachine : MonoBehaviour
    {
        // Public getter(s) for the states to check conditions
        public bool Debug => _debug;
        public PlayerControls PlayerInput => _playerInput;
        public CharacterController Controller => _controller;
        public Animator Animator => _animator;
        public HookController HookController => _hookController;
        public Transform GroundCheck => _groundCheck;
        
        [Header("Debug")]
        [SerializeField] private bool _debug;
#if UNITY_EDITOR
        [SerializeField] private DebugInitialState _initialState;
#endif
        
        [Header("Context Component")]
        [SerializeField] private Animator _animator;
        [SerializeField] private HookController _hookController;
        [SerializeField] private Transform _groundCheck;
        private APlayerState _currentState;
        private ASuperState _currentSuperState;
        private ASubState _currentSubState;
        private PlayerStateFactory _factory;
        private PlayerControls _playerInput;
        private CharacterController _controller;

        public void SwitchState(APlayerState nextState, bool hasSameSuperState)
        {
            _currentState.ExitState();
            _currentState = nextState;
            _currentState.EnterState();
        }

        public void SwitchSuperState(ASuperState nextSuperState)
        {
            _currentSuperState.ExitState();
            _currentSuperState = nextSuperState;
            _currentSuperState.EnterState();
        }
        
        public void SwitchSubState(ASubState nextSubState)
        {
            _currentSubState.ExitState();
            _currentSubState = nextSubState;
            _currentSubState.EnterState();
        }

        private void Awake()
        { 
            _factory = new PlayerStateFactory(this);
            _playerInput = new PlayerControls();
            _controller = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            _playerInput.Player.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Player.Disable();
        }

        private void Start()
        {
            // By default, the player begins with zero ability mounted and is in idle state
#if UNITY_EDITOR
            _currentState = _initialState switch
            {
                DebugInitialState.Basic => _factory.BasicIdle,
                _ => _factory.BasicIdle
            };
#else
            _currentState = _factory.BasicIdle;
#endif
            
            // There is no previous state in this case, so we enter this state fresh, thus false for the argument
            _currentState.EnterState();
        }

        private void Update()
        {
            _currentState.UpdateState();
        }
    }
    
    public enum DebugInitialState
    {
        Basic,
        Invis,
    }
}