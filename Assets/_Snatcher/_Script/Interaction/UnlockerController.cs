using UnityEngine;

namespace Snatcher
{
    public class UnlockerController : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool _debug;
        [Tooltip("Should an object be deleted after the user interacts with it?")]
        [SerializeField] private bool _destroyAfterInteraction;
        [Tooltip("The object to be destroyed. If Destroy After Interaction is false, this has no effect.")]
        [SerializeField] private GameObject _toDestroy;
        [Tooltip("The BoolReference whose value will change upon interaction.")]
        [SerializeField] private BoolReference _reference;
        [Tooltip("The boolean value that the value of Reference will change to upon interaction.")]
        [SerializeField] private bool _value;
        [Tooltip("The Void Event that will be raised upon interaction.")]
        [SerializeField] private VoidEvent _event;

        public void Interact()
        {
            if (_debug) 
                this.Log("Interact");
            
            _reference.Value = _value;
            
            if (_event != null)
                _event.Raise();
            
            if (_destroyAfterInteraction)
                Destroy(_toDestroy);
        }
    }
}