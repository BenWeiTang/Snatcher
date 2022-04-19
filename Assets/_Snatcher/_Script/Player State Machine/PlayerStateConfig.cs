using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/State Config", fileName = "New State Config")]
    public class PlayerStateConfig : ScriptableObject
    {
        [Header("Locomotion")]
        public float MoveSpeed;
        public float TurnSpeed;

        [Header("Gravity")]
        public float GroundedGravity = -0.05f;
        public float AirborneGravity = -9.8f;
        [Min(0f)]
        public float MaxFallSpeed = 100f;
        
        [Header("Visual")]
        public GameObject Limb;
    }
}