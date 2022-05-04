using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class DeathPlaneController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // Reload the current scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
