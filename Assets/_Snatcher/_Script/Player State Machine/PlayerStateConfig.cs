using System;
using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/State Config", fileName = "New State Config")]
    public class PlayerStateConfig : ScriptableObject
    {
        [Header("Locomotion")]
        public float MoveSpeed = 7.5f;
        public float TurnSpeed = 15f;

        [Header("Gravity")]
        public float GroundedGravity = -0.5f;
        public float AirborneGravity = -9.8f;
        [Min(0f)]
        public float MaxFallSpeed = 50f;
        
        [Header("Visual")]
        public GameObject Limb;

        private void Reset()
        {
            MoveSpeed = 7.5f;
            TurnSpeed = 15f;
            GroundedGravity = -0.5f;
            AirborneGravity = -9.8f;
            MaxFallSpeed = 50f;
            Limb = null;
        }
    }
}