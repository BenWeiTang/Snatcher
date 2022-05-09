using System;
using UnityEngine;

namespace Snatcher
{
    public class PlayerLimbController : MonoBehaviour
    {
        //[SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private VoidEvent _onLimbSwitched;
        [SerializeField] private Mesh _oneArmMesh;
        [SerializeField] private Mesh _twoArmMesh;

        [SerializeField] private GameObject _propellerLimb;
        [SerializeField] private GameObject _legLimb;

        private void OnEnable()
        {
            _onLimbSwitched.RegisterListener(OnLimbSwitched);
        }
        
        private void OnDisable()
        {
            _onLimbSwitched.UnregisterListener(OnLimbSwitched);
        }
        
        //TODO: delete later
        private void OnLimbSwitched(Void _)
        {
            if (LimbManager.Instance.CurrentLimb.Type == LimbType.Basic)
            {
                //_skinnedMeshRenderer.sharedMesh = _oneArmMesh;
                _propellerLimb.active = false;
                _legLimb.active = false;
            }
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Leg)
            {
                //_skinnedMeshRenderer.sharedMesh = _twoArmMesh;
                _legLimb.active = true;
            }
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Propeller)
            {
                //_skinnedMeshRenderer.sharedMesh = _twoArmMesh;
                _propellerLimb.active = true;
            }
        }
    }
}
