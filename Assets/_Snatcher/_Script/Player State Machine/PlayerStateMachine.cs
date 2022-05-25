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
        public Transform LimbSlot => _limbSlot;
        public ASuperState CurrentSuperState => _currentSuperState;
        public ASubState CurrentSubState => _currentSubState;
        public bool CanGrapple => _canGrapple.Value;
        public Vector3 GrappleDestination { get; set; }
        
        [Header("Debug")]
        [SerializeField] private bool _debug;
#if UNITY_EDITOR
        [SerializeField] private DebugInitialState _initialState;
#endif
        
        [Header("Context Component")]
        [SerializeField] private Animator _animator;
        [SerializeField] private HookController _hookController;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Transform _limbSlot;
        [SerializeField] private BoolReference _canGrapple;
        [SerializeField] private PlayerStateReference _currentSuperStateRef;
        [SerializeField] private PlayerStateReference _currentSubStateRef;
        private ASuperState _currentSuperState;
        private ASubState _currentSubState;
        private PlayerControls _playerInput;
        private CharacterController _controller;

        public void SwitchSuperState(ASuperState nextSuperState)
        {
            _currentSuperState.ExitState();
            _currentSuperState = nextSuperState;
            _currentSuperStateRef.Value = nextSuperState;
            _currentSuperState.EnterState();
        }
        
        public void SwitchSubState(ASubState nextSubState)
        {
            _currentSubState.ExitState();
            _currentSubState = nextSubState;
            _currentSubStateRef.Value = nextSubState;
            _currentSubState.EnterState();
        }

        private void Awake()
        { 
            _playerInput = new PlayerControls();
            _controller = GetComponent<CharacterController>();
            PlayerStateFactoryManager.Instance.InitContext(this);
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
            _currentSuperState = _initialState switch
            {
                DebugInitialState.Basic => PlayerStateFactoryManager.Instance.BasicState,
                DebugInitialState.Invis => PlayerStateFactoryManager.Instance.InvisState,
                _ => PlayerStateFactoryManager.Instance.BasicState
            };
            _currentSubState = PlayerStateFactoryManager.Instance.Idle;
#else
            _currentSuperState = PlayerStateFactoryManager.Instance.BasicState;
            _currentSubState = PlayerStateFactoryManager.Instance.Idle;
#endif
            
            // There is no previous state in this case, so we enter this state fresh, thus false for the argument
            _currentSuperState.EnterState();
            _currentSubState.EnterState();
        }

        private void Update()
        {
            _currentSuperState.UpdateState();
            _currentSubState.UpdateState();
        }
    }
    
    public enum DebugInitialState
    {
        Basic,
        Invis,
    }
}