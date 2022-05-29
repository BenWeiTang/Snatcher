using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class TeleportController : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool _debug;
        [SerializeField] private SceneIndex _targetScene;
        [SerializeField] private TeleportRequirement[] _requirements;
        [Tooltip("This should hold the reference to a hint text.")]
        [SerializeField] private TMP_Text _textRef;
        [Tooltip("This is the text that shows up when requirement(s) are not met.")]
        [SerializeField] private string _rejectionText;
        public void Interact()
        {
            if (_debug) this.Log("Interact");

            if (_requirements == null || _requirements.Length == 0)
            {
                return;
            }

            if (_requirements.All(r => r.Reference.Value == r.Requirement))
            {
                SceneManager.LoadScene((int)_targetScene);
            }
            else if (_textRef != null)
            {
                _textRef.text = _rejectionText;
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
