namespace Snatcher
{
    public abstract class APlayerState
    {
        protected bool IsRootState { set { _isRootState = value; } }
        protected PlayerStateMachine Context => _context;
        protected PlayerStateFactory Factory => _factory;

        private bool _isRootState = false;
        private PlayerStateMachine _context;
        private PlayerStateFactory _factory;
        private APlayerState _currentSubState;
        private APlayerState _currentSuperState;

        public APlayerState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory)
        {
            _context = currentContext;
            _factory = currentFactory;
        }

        public abstract void EnterState();


        public abstract void ExitState();

        public abstract void CheckSwitchState();

        public abstract void InitializeSubState();

        public void UpdateStates()
        {
            UpdateState();
            if (_currentSubState != null)
            {
                _currentSubState.UpdateStates();
            }
        }
        
        protected abstract void UpdateState();

        // public void ExitStates()
        // {
        //     ExitState();
        //     if (_currentSubState != null)
        //     {
        //         _currentSubState.ExitStates();
        //     }
        // }

        protected void SwitchState(APlayerState newState)
        {
            // Exit the current state
            ExitState();

            // Enter the new state
            newState.EnterState();

            if (_isRootState)
            {
                // Switch the current state in the context to newState
                _context.CurrentState = newState;
            }
            else if (_currentSuperState != null)
            {
                _currentSuperState.SetSubState(newState);
            }
        }

        protected void SetSuperState(APlayerState newSuperState)
        {
            _currentSuperState = newSuperState;
        }

        protected void SetSubState(APlayerState newSubState)
        {
            _currentSubState = newSubState;
            newSubState.SetSuperState(this);
        }
    }
}