using System;
using UnityEngine;

namespace Snatcher
{
    public class PlayerStateMachine : MonoBehaviour
    {
        public APlayerState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; }
        }
        private APlayerState _currentState;
        private PlayerStateFactory _states;

        private void Awake()
        {
            _states = new PlayerStateFactory(this);
            _currentState = _states.Grounded();
            _currentState.EnterState();
        }

        private void Update()
        {
            _currentState.UpdateStates();
        }
    }
}
