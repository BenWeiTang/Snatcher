using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class Cheater : MonoBehaviour
    {
        [SerializeField, Min(0)] private SceneIndex _targetScene;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _destination;

        private PlayerControls _playerInput;
        private Transform _playerPosition;
        private CharacterController _cc;

        private void OnEnable()
        {
            _playerInput = new PlayerControls();
            _playerInput.Debug.Enable();
            _playerInput.Debug.Cheat1.performed += OnCheatOnePressed;
            _playerInput.Debug.Cheat2.performed += OnCheatTwoPressed;
            _playerInput.Debug.Cheat3.performed += OnCheatThreePressed;
            _playerInput.Debug.Cheat4.performed += OnCheatFourPressed;
            
            ReferenceIntegrityCheck();
        }

        private void OnDisable()
        {
            _playerInput.Debug.Disable();
            _playerInput.Debug.Cheat1.performed -= OnCheatOnePressed;
            _playerInput.Debug.Cheat2.performed -= OnCheatTwoPressed;
            _playerInput.Debug.Cheat3.performed -= OnCheatThreePressed;
            _playerInput.Debug.Cheat4.performed -= OnCheatFourPressed;
        }
        
        private void OnCheatOnePressed(InputAction.CallbackContext callbackContext)
        {
            this.Log(1);
            SceneManager.LoadScene((int)_targetScene);
        }
        
        private void OnCheatTwoPressed(InputAction.CallbackContext callbackContext)
        {
            if (_playerPosition == null)
            {
                _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
                if (_playerPosition == null)
                {
                    this.LogError("Cannot find GameObject with tag Player");
                }
            }
            
            _cc.enabled = false;
            _playerPosition.position = _spawnPoint.position;
            _cc.enabled = true;
        }
        
        private void OnCheatThreePressed(InputAction.CallbackContext callbackContext)
        {
            if (_playerPosition == null)
            {
                _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
                if (_playerPosition == null)
                {
                    this.LogError("Cannot find GameObject with tag Player");
                }
            }

            _cc.enabled = false;
            _playerPosition.position = _destination.position;
            _cc.enabled = true;
        }

        private void OnCheatFourPressed(InputAction.CallbackContext callbackContext)
        {
            this.Log(4);
            Application.Quit();
        }
        
        private void ReferenceIntegrityCheck()
        {
            // Check if Player is placed in the scene
            _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
            _cc = _playerPosition.GetComponent<CharacterController>();
            if (_playerInput == null || _cc == null)
            {
                this.LogWarning("Did not find any GameObject with tag Player and a Character Controller component on it");
            }
            
            // Check if _targetSceneIndex is valid
            if ((int)_targetScene >= SceneManager.sceneCountInBuildSettings)
            {
                this.LogWarning("Target Scene Index is out of the range specified by the Build Settings");
            }
            
            // Check if _spawnPoint and _destination are set
            if (_spawnPoint == null)
            {
                this.LogWarning("Spawn Point is missing a reference");
            }
            if (_destination == null)
            {
                this.LogWarning("Destination is missing a reference");
            }
        }
    }
}
