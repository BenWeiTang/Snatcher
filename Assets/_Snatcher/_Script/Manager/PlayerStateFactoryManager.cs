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
        public LegState LegState { get; private set; }

        public WingState WingState { get; private set; }
        
        // Sub states
        public IdleState Idle { get; private set; }
        public MoveState Move { get; private set; }
        public FallState Fall { get; private set; }
        public DashState Dash { get; private set; }
        public HookOutState HookOut { get; private set; }
        public GrappleTowardState GrappleToward { get; private set; }
        public InvisIdleState InvisIdle { get; private set; }
        public InvisMoveState InvisMove { get; private set; }
        public VaultState Vault { get; private set; }
        public PropelState Propel { get; private set; }


        public void InitContext(PlayerStateMachine context)
        {
            // Cache instances of concrete states
            // Super states
            BasicState = new BasicState(context);
            InvisState = new InvisState(context);
            LegState = new LegState(context);
            WingState = new WingState(context);

            // Sub state
            Idle = new IdleState(context);
            Move = new MoveState(context);
            Fall = new FallState(context);
            Dash = new DashState(context);
            
            // Limb-specific ability states
            // Basic
            HookOut = new HookOutState(context);
            GrappleToward = new GrappleTowardState(context);
            // Invis
            InvisIdle = new InvisIdleState(context);
            InvisMove = new InvisMoveState(context);
            // Leg
            Vault = new VaultState(context);
            // Wing
            Propel = new PropelState(context);
        }
    }
}
