using System;
using UnityEngine;

namespace Snatcher
{
    public class PlayerLimbController : MonoBehaviour
    {
        //[SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private VoidEvent _onLimbSwitched;
        [SerializeField] private Mesh _oneArmMesh;
        //[SerializeField] private Mesh _twoArmMesh;

        [SerializeField] private SkinnedMeshRenderer _propellerLimb;
        [SerializeField] private SkinnedMeshRenderer _vaultArm;
        [SerializeField] private SkinnedMeshRenderer _vaultLegL;
        [SerializeField] private SkinnedMeshRenderer _vaultLegR;
        [SerializeField] private SkinnedMeshRenderer _defaultLegL;
        [SerializeField] private SkinnedMeshRenderer _defaultLegR;
        [SerializeField] private SkinnedMeshRenderer _defaultLeftArm;
        [SerializeField] private SkinnedMeshRenderer _defaultRightArm;

        private void OnEnable()
        {
            _propellerLimb.enabled = false;
            _vaultArm.enabled = false;
            _vaultLegL.enabled = false;
            _vaultLegR.enabled = false;
            _onLimbSwitched.RegisterListener(OnLimbSwitched);
        }
        
        private void OnDisable()
        {
            _onLimbSwitched.UnregisterListener(OnLimbSwitched);
        }
        
        private void OnLimbSwitched(Void _)
        {
            _propellerLimb.enabled = false;
            _vaultArm.enabled = false;
            _vaultLegL.enabled = false;
            _vaultLegR.enabled = false;

            if (LimbManager.Instance.CurrentLimb.Type == LimbType.Basic)
            {
                Debug.Log("Basic limb active, turninf odd propeller and vault");
                _defaultLegL.enabled = true;
                _defaultLegR.enabled = true;
                _defaultLeftArm.enabled = true;
                _propellerLimb.enabled = false;
                _vaultArm.enabled = false;
                _vaultLegL.enabled = false;
                _vaultLegR.enabled = false;
                //_skinnedMeshRenderer.sharedMesh = _oneArmMesh;
            }
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Leg)
            {
                _vaultArm.enabled = true;
                _vaultLegL.enabled = true;
                _vaultLegR.enabled = true;
                _defaultLeftArm.enabled = false;
                _defaultLegL.enabled = false;
                _defaultLegR.enabled = false;
                //_skinnedMeshRenderer.sharedMesh = _propellerLimb;
                //_skinnedMeshRenderer.BakeMesh(_propellerLimb);
            }
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Propeller)
            {
                _propellerLimb.enabled = true;
                _defaultLegL.enabled = true;
                _defaultLegR.enabled = true;
                _defaultLeftArm.enabled = true;
                //_skinnedMeshRenderer.sharedMesh = _legLimb;
                //_skinnedMeshRenderer.BakeMesh(_legLimb);
            }
        }
    }
}
