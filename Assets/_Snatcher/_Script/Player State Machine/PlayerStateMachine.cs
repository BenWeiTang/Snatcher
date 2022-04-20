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
        
        [SerializeField] private bool _debug;
        [SerializeField] private Animator _animator;
        [SerializeField] private HookController _hookController;
        [SerializeField] private Transform _groundCheck;
        private APlayerState _currentState;
        private PlayerStateFactory _factory;
        private PlayerControls _playerInput;
        private CharacterController _controller;

        public void SwitchState(APlayerState nextState, bool hasSameSuperState)
        {
            _currentState.ExitState();
            _currentState = nextState;
            _currentState.EnterState(hasSameSuperState);
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
            // _currentState = _factory.BasicIdle;
            _currentState = _factory.BasicIdle;
            
            // There is no previous state in this case, so we enter this state fresh, thus false of the argument
            _currentState.EnterState(false);
        }

        private void Update()
        {
            _currentState.UpdateState();
        }
    }
}