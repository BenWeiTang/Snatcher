using UnityEngine;
using DG.Tweening;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/State Config", fileName = "New State Config")]
    public class PlayerStateConfig : ScriptableObject
    {
        [Header("Locomotion")]
        public float MoveSpeed = 7.5f;
        public float TurnSpeed = 15f;

        [Header("Gravity")]
        public float GroundedGravity = -5f;
        public float AirborneGravity = -9.8f;
        [Min(0f), Tooltip("The maximum speed the character will reach when falling. Values grater than Max Fall Speed will be capped.")]
        public float MaxFallSpeed = 50f;

        [Header("Dash")]
        public float DashDuration = 0.5f;
        public float DashDistance = 5f;
        public Ease EaseMode;

        [Header("Hook")]
        [Range(0f, 1f), Tooltip("How long it takes from the Hook Button being pressed to the Hook Hit Box is activated. Measure in seconds.")]
        public float StartupWindow = 0.25f;
        [Range(0f, 1f), Tooltip("How long the Hook Hit Box stays active. Measure in seconds.")]
        public float ActiveWindow = 0.25f;

        [Header("Visual")]
        public GameObject Limb;

        private void Reset()
        {
            // Locomotion
            MoveSpeed = 7.5f;
            TurnSpeed = 15f;
            
            // Gravity
            GroundedGravity = -5f;
            AirborneGravity = -9.8f;
            MaxFallSpeed = 50f;
            
            // Dash
            DashDuration = 0.5f;
            DashDistance = 5f;
            
            // Hook
            StartupWindow = 0.25f;
            ActiveWindow = 0.25f;
            
            Limb = null;
        }
    }
}