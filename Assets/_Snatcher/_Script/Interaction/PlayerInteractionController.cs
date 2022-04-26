using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public class PlayerInteractionController : MonoBehaviour
    {
        private PlayerControls _playerControls;
        private IInteractable _interactable;
        private InputAction _useAbility;

        private void Awake()
        {
            _playerControls = new PlayerControls();
            _playerControls.Enable();
            _useAbility = _playerControls.Player.Interact;
        }
        private void OnEnable() => _useAbility.performed += OnInteractPressed;
        private void OnDisable() => _useAbility.performed -= OnInteractPressed;
        private void OnTriggerEnter(Collider other) => _interactable = other.GetComponent<IInteractable>();
        private void OnTriggerExit(Collider other) => _interactable = null;
        private void OnInteractPressed(InputAction.CallbackContext callbackContext) => _interactable?.Interact();
    }
}
