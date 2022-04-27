using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class TeleportController : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool _debug;
        [SerializeField] private int _targetSceneIndex;
        [SerializeField] private BoolReference[] _requirements;
        public void Interact()
        {
            if (_debug) this.Log("Interact");

            if (_requirements == null || _requirements.Length == 0 || _requirements.All(r => r.Value))
            {
                SceneManager.LoadScene(_targetSceneIndex);
            }
        }
    }
}
