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
        [SerializeField] private FloatReference _hookLength;

        // Remove later; for debug use only
        [SerializeField] private MeshRenderer _meshRenderer;
        

        public void ActivateCollider(bool toActivate)
        {
            _meshRenderer.enabled = toActivate;
            _collider.enabled = toActivate;
        }
        
        private void Update()
        {
            Transform t = transform;
            Vector3 localScale = t.localScale;
            localScale.z = _hookLength.Value;
            t.localScale = localScale;
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