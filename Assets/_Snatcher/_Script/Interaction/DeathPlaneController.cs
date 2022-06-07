using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class DeathPlaneController : MonoBehaviour
    {
        [SerializeField] private IntReference _snatcherLastScene;

        public void Start()
        {
            _snatcherLastScene.Value = SceneManager.GetActiveScene().buildIndex;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // Reload the current scene
                SceneManager.LoadScene((int)SceneIndex.DeathByFalling);
            }
        }
    }
}
