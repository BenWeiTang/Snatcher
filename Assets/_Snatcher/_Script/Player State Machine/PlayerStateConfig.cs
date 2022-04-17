using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/State Config", fileName = "New State Config")]
    public class PlayerStateConfig : ScriptableObject
    {
        public float MoveSpeed;
        public float TurnSpeed;
        
        public GameObject Limb;
    }
}