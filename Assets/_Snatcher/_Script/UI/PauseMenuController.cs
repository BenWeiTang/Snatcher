using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        //[SerializeField] private CanvasGroup _pauseMenuGroup;
        //[SerializeField] private CanvasGroup _parameterCanvasGroup;
        //[SerializeField] private bool _hasKey;

        private CanvasGroup [] _canvasGroups;

        private bool _isOn;
        // Start is called before the first frame update
        void Start()
        {
            _pauseMenu.SetActive(false);
            _canvasGroups = _pauseMenu.GetComponentsInChildren<CanvasGroup>();
            SetAllUiPanelInactive();
            SetPauseCanvasGroupActive();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //Set Canvas active or inactive
                //_isOn = !_isOn;
                //TogglePauseMenu(_isOn);
                TogglePauseMenu();
                

                //SetCanvasGroupActivate(_isOn);
            }
        }

        private void SetCanvasGroupActivate(bool toActivate, CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = toActivate ? 1f : 0f;
            canvasGroup.blocksRaycasts = toActivate;
            canvasGroup.interactable = toActivate;
        }

        public void Pause() {
            Time.timeScale = 0;
            _pauseMenu.SetActive(true);
        }

        public void Resume() {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        private void SetAllUiPanelInactive() {
            foreach (CanvasGroup canvasGroup in _canvasGroups) {
                SetCanvasGroupActivate(false, canvasGroup);
            }
        }

        public void SetPauseCanvasGroupActive() {
           SetAllUiPanelInactive();
           SetCanvasGroupActivate(true, _canvasGroups[0]);
        }

        public void SetParametersCanvasGroupActive() {
            SetAllUiPanelInactive();
            SetCanvasGroupActivate(true, _canvasGroups[1]);
        }

        public void ReturnToMainMenu() {
            SceneManager.LoadScene("MainMenu");
        }

        public void Restart() {
            SceneManager.LoadScene("Alpha_UpperWorld");
            gameObject.GetComponent<GameStateManager>().Reset();
        }

        public void TogglePauseMenu() {
            if (_pauseMenu.activeSelf) {
                Resume();
            } else {
                Pause();
            }
        }
    }
}
