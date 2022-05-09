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
            _propellerLimb.SetActive(false);
            _legLimb.SetActive(false);
            _onLimbSwitched.RegisterListener(OnLimbSwitched);
        }
        
        private void OnDisable()
        {
            _onLimbSwitched.UnregisterListener(OnLimbSwitched);
        }
        
        private void OnLimbSwitched(Void _)
        {
            _propellerLimb.SetActive(false);
            _legLimb.SetActive(false);

            if (LimbManager.Instance.CurrentLimb.Type == LimbType.Basic)
            {
                //_skinnedMeshRenderer.sharedMesh = _oneArmMesh;
                _propellerLimb.SetActive(false);
                _legLimb.SetActive(false);
            }
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Leg)
            {
                //_skinnedMeshRenderer.sharedMesh = _twoArmMesh;
                _legLimb.SetActive(true);
            }
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Invis)
            {
                //_skinnedMeshRenderer.sharedMesh = _twoArmMesh;
                _propellerLimb.SetActive(true);
            }
        }
    }
}
