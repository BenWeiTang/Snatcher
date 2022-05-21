using System;
using UnityEngine;

namespace Snatcher
{
    public class PlayerLimbController : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private VoidEvent _onLimbSwitched;
        //[SerializeField] private Mesh _defaultMesh;
        //[SerializeField] private Mesh _propellerMesh;
        //[SerializeField] private Mesh _vaultMesh;

        //[SerializeField] private GameObject _propellerLimb;
        //[SerializeField] private GameObject _legLimb;

        private void OnEnable()
        {
            //_propellerLimb.SetActive(false);
            //_legLimb.SetActive(false);
            _onLimbSwitched.RegisterListener(OnLimbSwitched);
        }
        
        private void OnDisable()
        {
            _onLimbSwitched.UnregisterListener(OnLimbSwitched);
        }
        
        private void OnLimbSwitched(Void _)
        {
            //_propellerLimb.SetActive(false);
            //_legLimb.SetActive(false);

            if (LimbManager.Instance.CurrentLimb.Type == LimbType.Basic)
            {
                //_propellerLimb.SetActive(false);
                //_legLimb.SetActive(false);
                //_skinnedMeshRenderer.sharedMesh = _vaultMesh;
            }
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Leg)
            {
                //_legLimb.SetActive(true);
                //_skinnedMeshRenderer.sharedMesh = _propellerLimb;
                //_skinnedMeshRenderer.BakeMesh(_propellerLimb);
                //_skinnedMeshRenderer.sharedMesh = _vaultMesh;
            }
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Propeller)
            {
                //_propellerLimb.SetActive(true);
                //_skinnedMeshRenderer.sharedMesh = _legLimb;
                //_skinnedMeshRenderer.BakeMesh(_legLimb);
                //_skinnedMeshRenderer.sharedMesh = _propellerMesh;
            }
        }
    }
}
