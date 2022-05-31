using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private BoolReference _needsIntro;
        [SerializeField] private BoolReference _dungeon2KeyRef;
        [SerializeField] private BoolReference _dungeon3KeyRef;
        [SerializeField] private BoolReference _dungeon4KeyRef;
        public void Start()
        {
            _needsIntro.Value = true;
            _dungeon2KeyRef.Value = false;
            _dungeon3KeyRef.Value = false;
            _dungeon4KeyRef.Value = false;

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
