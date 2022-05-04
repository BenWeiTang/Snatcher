using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Manager/InputModeManager", fileName = "InputModeManager")]
    public class InputModeManager : ASingletonScriptableObject<InputModeManager>
    {
        // This manager is responsible for toggling between different input mode
        // We don't want player to fire hook when clicking a UI element
        
        [SerializeField] private bool _debug;
        private PlayerControls _playerControls;

        public void ToggleMode()
        {
            
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            
            _playerControls = new PlayerControls();
            SceneManager.sceneLoaded += OnSceneLoaded;
            
            if (_debug) this.LogSuccess("Initialized");
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            
        }
    }
}