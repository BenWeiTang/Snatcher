using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class WinScreenController : MonoBehaviour
    {
        public void Exit()
        {
            SceneManager.LoadSceneAsync((int)SceneIndex.MainMenu);
        }
    }
}
