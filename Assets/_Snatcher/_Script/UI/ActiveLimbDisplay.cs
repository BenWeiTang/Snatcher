using UnityEngine;
using UnityEngine.UI;

namespace Snatcher
{
    public class ActiveLimbDisplay : MonoBehaviour
    {
        [Header("Debug")]
        [SerializeField] private bool _debug;
        
        [Header("Text Display")]
        [SerializeField] private GameObject _currentLimbDisplay;
        [SerializeField] private GameObject _priorLimbDisplay;
        [SerializeField] private GameObject _nextLimbDisplay;
        [SerializeField] private GameObject _activeDurabilityDisplay;

        [Header("Event")]
        [SerializeField] private VoidEvent _onLimbSwitched;

        private Text _currentLimbDisplayText;
        private Text _priorLimbDisplayText;
        private Text _nextLimbDisplayText;
        private Text _activeDurabilityText;
        
        private void Awake()
        {
            _currentLimbDisplayText = _currentLimbDisplay.GetComponent<Text>();
            _priorLimbDisplayText = _priorLimbDisplay.GetComponent<Text>();
            _nextLimbDisplayText = _nextLimbDisplay.GetComponent<Text>();
            _activeDurabilityText = _activeDurabilityDisplay.GetComponent<Text>();
        }

        private void Start()
        {
            UpdateUIDisplay(new Void()); // Weird syntax I know -Ben 4/23/2022
        }

        private void OnEnable() => _onLimbSwitched.RegisterListener(UpdateUIDisplay);
        private void OnDisable() => _onLimbSwitched.UnregisterListener(UpdateUIDisplay);

        private void UpdateUIDisplay(Void _)
        {
            if (_debug)
            {
                this.Log($"Current Limb: {LimbManager.Instance.CurrentLimb.Name}.");
            }
            
            // Current limb name
            _currentLimbDisplayText.text = LimbManager.Instance.CurrentLimb != null ? LimbManager.Instance.CurrentLimb.Name : "";
            _priorLimbDisplayText.text = LimbManager.Instance.PriorLimb != null ? LimbManager.Instance.PriorLimb.Name : "";
            _nextLimbDisplayText.text = LimbManager.Instance.NextLimb != null ? LimbManager.Instance.NextLimb.Name : "";
            _activeDurabilityText.text = LimbManager.Instance.CurrentLimb.Durability + "/" + LimbManager.Instance.CurrentLimb.MaxDurability;
        }
    }
}
