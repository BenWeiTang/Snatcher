using UnityEngine;
using UnityEngine.InputSystem;

namespace Snatcher
{
    public class TestingInputSystem : MonoBehaviour
    {
        public void OnSnatch(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                this.Log(context.ReadValue<Vector2>());
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                this.Log(context.ReadValue<Vector2>());
            }
        }
    }
}
