using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class LandingIndicatorController : MonoBehaviour
    {
        [SerializeField] private GameObject _followedObject;
        [SerializeField] private PlayerStateReference _currentSubStateRef;
        private RaycastHit _raycastHit;
        private Ray _ray;
        private GameObject _indicator;

        private void Start()
        {
            _indicator = gameObject.transform.GetChild(0).gameObject;
        }

        private void Update()
        {
            if(_currentSubStateRef.Value?.GetType() == typeof(PropelState))
            {
                _indicator.SetActive(true);
                _ray = new Ray(_followedObject.transform.position, Vector3.down);
                if(Physics.Raycast(_ray, out _raycastHit)) 
                    transform.position = _raycastHit.point + new Vector3(0f,0.25f,0);
                return;
            }
            _indicator.SetActive(false);
        }
    }
}
