using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class TeleportController : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool _debug;
        [SerializeField] private SceneIndex _targetScene;
        [SerializeField] private TeleportRequirement[] _requirements;
        public void Interact()
        {
            if (_debug) this.Log("Interact");

            if (_requirements == null || _requirements.Length == 0 || _requirements.All(r => r.Reference.Value == r.Requirement))
            {
                SceneManager.LoadScene((int)_targetScene);
            }
        }
    }

    [System.Serializable]
    public struct TeleportRequirement
    {
        public BoolReference Reference => _reference;
        public bool Requirement => _requirement;
        [Tooltip("The BoolReference to check against.")]
        [SerializeField] private BoolReference _reference;
        [Tooltip("The boolean value requirement for the BoolReference to meet.")]
        [SerializeField] private bool _requirement;
    }
}
