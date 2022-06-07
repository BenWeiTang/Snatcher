using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public class KeyCheater : MonoBehaviour
    {
        [SerializeField] private BoolReference _key1;
        [SerializeField] private BoolReference _key2;
        [SerializeField] private BoolReference _key3;
        [SerializeField] private BoolReference _key4;
        [SerializeField] private VoidEvent _onKeyObtained;

        private PlayerControls _playerInput;
        
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
            _key1.Value = !_key1.Value;
            _onKeyObtained.Raise();
        }

        private void OnCheatTwoPressed(InputAction.CallbackContext callbackContext)
        {
            _key2.Value = !_key2.Value;
            _onKeyObtained.Raise();
        }

        private void OnCheatThreePressed(InputAction.CallbackContext callbackContext)
        {
            _key3.Value = !_key3.Value;
            _onKeyObtained.Raise();
        }

        private void OnCheatFourPressed(InputAction.CallbackContext callbackContext)
        {
            _key4.Value = !_key4.Value;
            _onKeyObtained.Raise();
        }

        private void ReferenceIntegrityCheck()
        {
            if (_key1 == null)
                this.LogWarning("Key 1 is missing a reference.");
            if (_key2 == null)
                this.LogWarning("Key 2 is missing a reference.");
            if (_key3 == null)
                this.LogWarning("Key 3 is missing a reference.");
            if (_key4 == null)
                this.LogWarning("Key 4 is missing a reference.");
            if (_onKeyObtained == null)
                this.LogWarning("On Key Obtained event is missing a reference.");
        }
    }
}