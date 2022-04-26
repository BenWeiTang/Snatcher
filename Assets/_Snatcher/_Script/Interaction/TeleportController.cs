using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class TeleportController : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool _debug;
        [SerializeField] private int _targetSceneIndex;
        public void Interact()
        {
            if (_debug) this.Log("Interact");
            SceneManager.LoadScene(_targetSceneIndex);
        }
    }
}
