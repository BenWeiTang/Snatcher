using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Manager/PlayerStateFactoryManager", fileName = "PlayerStateFactoryManager")]
    public class PlayerStateFactoryManager : ASingletonScriptableObject<PlayerStateFactoryManager>
    {
        // Instances of concrete states
        // Super states
        public BasicState BasicState { get; private set; }
        public InvisState InvisState { get; private set; }
        
        // Sub states
        public IdleState Idle { get; private set; }
        public MoveState Move { get; private set; }
        public FallState Fall { get; private set; }
        public DashState Dash { get; private set; }
        public HookOutState HookOut { get; private set; }
        public HookInState HookIn { get; private set; }
        public InvisIdleState InvisIdle { get; private set; }

        // Context instance
        public PlayerStateMachine Context { get; set; }
        
        public void InitContext(PlayerStateMachine context)
        {
            Context = context;
            
            // Cache instances of concrete states
            // Super states
            BasicState = new BasicState(Context);
            InvisState = new InvisState(Context);

            // Sub state
            Idle = new IdleState(Context);
            Move = new MoveState(Context);
            Fall = new FallState(Context);
            Dash = new DashState(Context);
            HookOut = new HookOutState(Context);
            HookIn = new HookInState(Context);
            
            // Limb-specific ability states
            InvisIdle = new InvisIdleState(Context);
        }
    }
}
