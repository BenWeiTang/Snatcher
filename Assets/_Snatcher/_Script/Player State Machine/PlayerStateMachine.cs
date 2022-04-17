using System;
using UnityEngine;

namespace Snatcher
{
    public class PlayerStateMachine : MonoBehaviour
    {
        // Public getter(s) for the states to check conditions
        public PlayerControls PlayerInput => _playerInput;
        
        private APlayerState _currentState;
        private PlayerStateFactory _factory;
        private PlayerControls _playerInput;

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
