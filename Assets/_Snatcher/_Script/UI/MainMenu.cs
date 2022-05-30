using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private BoolReference _needsIntro;

        public void Start()
        {
            _needsIntro.Value = true;
        }

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
