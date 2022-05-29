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

        [SerializeField] private SkinnedMeshRenderer _wingLimb;
        [SerializeField] private SkinnedMeshRenderer _vaultArm;
        [SerializeField] private SkinnedMeshRenderer _vaultLegL;
        [SerializeField] private SkinnedMeshRenderer _vaultLegR;
        [SerializeField] private SkinnedMeshRenderer _defaultLegL;
        [SerializeField] private SkinnedMeshRenderer _defaultLegR;
        [SerializeField] private SkinnedMeshRenderer _defaultLeftArm;
        [SerializeField] private SkinnedMeshRenderer _defaultRightArm;
        [SerializeField] private PlayerStateReference _currentPlayerSubState;

        private void OnEnable()
        {
            _wingLimb.enabled = false;
            _vaultArm.enabled = false;
            _vaultLegL.enabled = false;
            _vaultLegR.enabled = false;
            _onLimbSwitched.RegisterListener(OnLimbSwitched);
        }
        
        private void OnDisable()
        {
            _onLimbSwitched.UnregisterListener(OnLimbSwitched);
        }
        
        private void Update()
        {
            if (_currentPlayerSubState.Value != null)
            {
                // Debug.Log(_currentPlayerSubState.Value.ToString());
                var currentType = _currentPlayerSubState.Value.GetType();
                if (currentType == typeof(InvisIdleState) || currentType == typeof(InvisMoveState))
                {
                    LimbManager.Instance.RecoverStamina(-9f * Time.deltaTime);
                }
                else
                {
                    LimbManager.Instance.RecoverStamina(5f * Time.deltaTime);
                }
            }
        }

        private void OnLimbSwitched(Void _)
        {
            _wingLimb.enabled = false;
            _vaultArm.enabled = false;
            _vaultLegL.enabled = false;
            _vaultLegR.enabled = false;

            if (LimbManager.Instance.CurrentLimb.Type == LimbType.Basic)
            {
                Debug.Log("Basic limb active, turninf odd propeller and vault");
                _defaultLegL.enabled = true;
                _defaultLegR.enabled = true;
                _defaultLeftArm.enabled = true;
                _wingLimb.enabled = false;
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
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Wing)
            {
                _wingLimb.enabled = true;
                _defaultLegL.enabled = true;
                _defaultLegR.enabled = true;
                _defaultLeftArm.enabled = true;
                //_skinnedMeshRenderer.sharedMesh = _legLimb;
                //_skinnedMeshRenderer.BakeMesh(_legLimb);
            }
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Invis)
            {
                _defaultLegL.enabled = true;
                _defaultLegR.enabled = true;
                _defaultLeftArm.enabled = true;
                _wingLimb.enabled = false;
                _vaultArm.enabled = false;
                _vaultLegL.enabled = false;
                _vaultLegR.enabled = false;
                //_skinnedMeshRenderer.sharedMesh = _oneArmMesh;
            }
        }
    }
}
