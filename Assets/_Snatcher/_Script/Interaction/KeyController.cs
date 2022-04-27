using UnityEngine;

namespace Snatcher
{
    public class KeyController : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject _toDestroy;
        [SerializeField] private BoolReference _hasKey;
        public void Interact()
        {
            _hasKey.Value = true;
            Destroy(_toDestroy);
        }
    }
}