using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Manager/State Config Manager", fileName = "State Config Manager")]
    public class StateConfigManager : ASingletonScriptableObject<StateConfigManager>
    {
        public PlayerStateConfig BasicStateConfig;
        public PlayerStateConfig InvisStateConfig;
<<<<<<< HEAD
=======
        public PlayerStateConfig LegStateConfig;

        public PlayerStateConfig WingStateConfig;
>>>>>>> dev
    }
}