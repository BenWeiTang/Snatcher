using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class Init : MonoBehaviour
    {
        private void Awake() => SceneManager.LoadScene((int)SceneIndex.MainMenu);
    }
}
