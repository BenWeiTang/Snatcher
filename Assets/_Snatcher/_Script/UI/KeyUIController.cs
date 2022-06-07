using UnityEngine;

namespace Snatcher
{
    public class KeyUIController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _keysToDisplay;
        [SerializeField] private BoolReference[] _keysToDisplayRef;
        [SerializeField] private VoidEvent _onKeyObtained;
        [SerializeField] private float keyCanvasGroupAlpha;

        private void Start()
        {
            UpdateKeyUI(new Void());
        }
        
        private void OnEnable()
        {
            _onKeyObtained.RegisterListener(UpdateKeyUI);
        }

        private void OnDisable()
        {
            _onKeyObtained.UnregisterListener(UpdateKeyUI);
        }

        private void UpdateKeyUI(Void _) {
            for(int i=0; i<_keysToDisplay.Length; i++) {
                _keysToDisplay[i].GetComponent<CanvasGroup>().alpha = _keysToDisplayRef[i].Value ? 1f : keyCanvasGroupAlpha;
            }
        }
    }
}
