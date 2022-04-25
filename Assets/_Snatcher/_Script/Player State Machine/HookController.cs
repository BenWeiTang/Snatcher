using System;
using UnityEngine;

namespace Snatcher
{
    public class HookController : MonoBehaviour
    {
        //TODO: we want to read what type of enemy we hit
        //TODO: we want to determine if the timing is right and we can snatch the ability
        public event Action OnEnemyHit;
        public event Action<Vector3> OnGrappleHit;
        
        [SerializeField] private BoxCollider _collider;

        // Remove later; for debug use only
        private MeshRenderer _meshRenderer;

        public void ActivateCollider(bool toActivate)
        {
            _meshRenderer.enabled = toActivate;
            _collider.enabled = toActivate;
        }

        private void Awake()
        {
            // Remove later; for debug use only
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                OnEnemyHit?.Invoke();
            }
            else if (other.CompareTag("Grapple"))
            {
                OnGrappleHit?.Invoke(other.transform.position);
            }
        }
    }
}