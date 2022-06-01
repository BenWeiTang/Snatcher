using System;
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
<<<<<<< HEAD
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
=======
                SceneManager.LoadScene((int)SceneIndex.DeathByFalling);
>>>>>>> dev
            }
        }
    }
}
