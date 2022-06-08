using System;
using UnityEngine;

namespace Snatcher
{
    public class PlayerLimbController : MonoBehaviour
    {
        [SerializeField] private bool _equipForDebug;

        //[SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private VoidEvent _onLimbSwitched;
        [SerializeField] private Mesh _oneArmMesh;
        //[SerializeField] private Mesh _twoArmMesh;

        [SerializeField] private MeshRenderer _wingLimb;
        [SerializeField] private MeshRenderer _invisLimb;
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
            if (_equipForDebug)
            {
                LimbManager.Instance.TryAddLimb(LimbType.Invis);
                LimbManager.Instance.TryAddLimb(LimbType.Wing);
                LimbManager.Instance.TryAddLimb(LimbType.Leg);
            }
            _wingLimb.enabled = false;
            _vaultArm.enabled = false;
            _vaultLegL.enabled = false;
            _vaultLegR.enabled = false;
            _invisLimb.enabled = false;
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
                    LimbManager.Instance.RecoverStamina(7f * Time.deltaTime);
                }
            }
        }

        private void OnLimbSwitched(Void _)
        {
            _wingLimb.enabled = false;
            _vaultArm.enabled = false;
            _vaultLegL.enabled = false;
            _vaultLegR.enabled = false;
            _invisLimb.enabled = false;

            _defaultLeftArm.enabled = true;
            _defaultLegL.enabled = true;
            _defaultLegR.enabled = true;
            _defaultRightArm.enabled = true;

            if (LimbManager.Instance.CurrentLimb.Type == LimbType.Basic)
            {
            }
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Leg)
            {
                _vaultArm.enabled = true;
                _vaultLegL.enabled = true;
                _vaultLegR.enabled = true;

                _defaultLeftArm.enabled = false;
                _defaultLegL.enabled = false;
                _defaultLegR.enabled = false;
            }
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Wing)
            {
                _wingLimb.enabled = true;
            }
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Invis)
            {
                _invisLimb.enabled = true;
            }
        }
    }
}
