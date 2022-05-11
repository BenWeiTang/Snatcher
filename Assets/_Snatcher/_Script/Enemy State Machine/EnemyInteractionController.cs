using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class EnemyInteractionController : MonoBehaviour, ISnatchable
    {
        [SerializeField] private LimbType _type;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene((int)SceneIndex.LoseScene);
            }
        }

        public LimbType RequestSnatchLimb() => _type;
    }
}