using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private BoolReference _needsIntro;
        [SerializeField] private BoolReference[] _dungeonKeyRefs;

        public void Start()
        {
            _needsIntro.Value = true;
            foreach (BoolReference keyRef in _dungeonKeyRefs)
            {
                keyRef.Value = false;
            }

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
