using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Manager/State Config Manager", fileName = "New State Config Manager")]
    public class StateConfigManager : ASingletonScriptableObject<StateConfigManager>
    {
        public PlayerStateConfig BasicStateConfig;
    }
}