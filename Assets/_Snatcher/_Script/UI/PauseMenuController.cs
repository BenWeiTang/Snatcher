using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        
        private CanvasGroup[] _canvasGroups;
        private bool _isOn;

        private void Start()
        {
            _pauseMenu.SetActive(false);
            _canvasGroups = _pauseMenu.GetComponentsInChildren<CanvasGroup>();
            SetAllUiPanelInactive();
            SetPauseCanvasGroupActive();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePauseMenu();
            }
        }

        public void Pause()
        {
            Time.timeScale = 0;
            _pauseMenu.SetActive(true);
        }

        public void Resume()
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        
        public void SetPauseCanvasGroupActive()
        {
            SetAllUiPanelInactive();
            SetCanvasGroupActivate(true, _canvasGroups[0]);
        }

        public void SetParametersCanvasGroupActive()
        {
            SetAllUiPanelInactive();
            SetCanvasGroupActivate(true, _canvasGroups[1]);
        }

        public void ReturnToMainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene((int)SceneIndex.MainMenu);
        }

        public void Restart()
        {
            gameObject.GetComponent<GameStateManager>().Reset();
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void TogglePauseMenu()
        {
            if (_pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
        private void SetCanvasGroupActivate(bool toActivate, CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = toActivate ? 1f : 0f;
            canvasGroup.blocksRaycasts = toActivate;
            canvasGroup.interactable = toActivate;
        }
        
        private void SetAllUiPanelInactive()
        {
            foreach (CanvasGroup canvasGroup in _canvasGroups)
            {
                SetCanvasGroupActivate(false, canvasGroup);
            }
        }
    }
}