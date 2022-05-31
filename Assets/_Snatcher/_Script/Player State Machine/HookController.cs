using System;
using UnityEngine;

namespace Snatcher
{
    public class HookController : MonoBehaviour
    {
        public event Action<LimbType> OnEnemyHit;
        public event Action<Vector3> OnGrappleHit;
        
        [SerializeField] private BoxCollider _collider;
        [SerializeField] private FloatReference _hookLength;
        [SerializeField] private Transform _hookPivot;

        // Remove later; for debug use only
        [SerializeField] private MeshRenderer _meshRenderer;
        private Boolean _rotating = false;
        private Vector3 _initialPosition;
        private Quaternion _initialRotation;

        public void Start()
        {
            _initialRotation = transform.localRotation;
            transform.RotateAround(_hookPivot.position, Vector3.up, 30);
            _initialPosition = transform.localPosition;
        }
        public void ActivateCollider(bool toActivate)
        {
            _meshRenderer.enabled = toActivate;
            _collider.enabled = toActivate;
            _rotating = true;
        }
        
        private void Update()
        {
            Transform t = transform;
            Vector3 localScale = t.localScale;
            localScale.z = _hookLength.Value;
            t.localScale = localScale;
            if (_rotating)
            {
                t.RotateAround(_hookPivot.position, Vector3.down, 200  * Time.deltaTime);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                var snatchable = other.GetComponent<ISnatchable>();
                
                if (snatchable != null)
                {
                    var type = snatchable.RequestSnatchLimb();
                    OnEnemyHit?.Invoke(type);
                }
            }
            else if (other.CompareTag("Grapple"))
            {
                OnGrappleHit?.Invoke(other.transform.position);
            }
        }

        public void ResetRotation()
        {
            transform.localRotation = _initialRotation;
            transform.RotateAround(_hookPivot.position, Vector3.up, 20);
            transform.localPosition = _initialPosition;
            _rotating = false;
        }
    }
}