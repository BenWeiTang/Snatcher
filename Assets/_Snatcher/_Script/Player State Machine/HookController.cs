using System;
using UnityEngine;

namespace Snatcher
{
    public class HookController : MonoBehaviour
    {
        //TODO: we want to read what type of enemy we hit
        //TODO: we want to determine if the timing is right and we can snatch the ability
        public event Action OnEnemyHit;
        [SerializeField] private BoxCollider _collider;

        public void ActivateCollider(bool toActivate) => _collider.enabled = toActivate;

        private void OnTriggerEnter(Collider other)
        {
            OnEnemyHit?.Invoke();
        }
    }
}