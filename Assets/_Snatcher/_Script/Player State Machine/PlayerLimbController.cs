using System;
using UnityEngine;

namespace Snatcher
{
    public class PlayerLimbController : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private VoidEvent _onLimbSwitched;
        [SerializeField] private Mesh _oneArmMesh;
        [SerializeField] private Mesh _twoArmMesh;

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
                _skinnedMeshRenderer.sharedMesh = _oneArmMesh;
            }
            else if (LimbManager.Instance.CurrentLimb.Type == LimbType.Invis)
            {
                _skinnedMeshRenderer.sharedMesh = _twoArmMesh;
            }
        }
    }
}
