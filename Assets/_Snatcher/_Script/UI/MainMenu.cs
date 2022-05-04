using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene((int)SceneIndex.UpperWorld);
        }

        public void PlayTutorial()
        {
            SceneManager.LoadScene((int)SceneIndex.TutorialUpperWorld);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
