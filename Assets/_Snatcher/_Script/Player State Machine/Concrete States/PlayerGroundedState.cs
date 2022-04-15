
namespace Snatcher
{
    public class PlayerGroundedState : APlayerState
    {
        public PlayerGroundedState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory)
        {
            IsRootState = true;
            InitializeSubState();
        }

        public override void EnterState()
        {
        }

        public override void ExitState()
        {
        }

        public override void CheckSwitchState()
        {
        }

        public override void InitializeSubState()
        {
        }
        
        protected override void UpdateState()
        {
            CheckSwitchState();
        }
    }
}
