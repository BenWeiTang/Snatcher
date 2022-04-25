using UnityEngine;
using UnityEngine.UI;
using Input = UnityEngine.Input;
using TMPro;
using System;

namespace Snatcher
{
    public class ParamScreenController : MonoBehaviour
    {
        [Header("UI Element")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Slider _playerDashDistanceOrSpeedSlider;
        [SerializeField] private Slider _playerTurnSpeedSlider;
        [SerializeField] private Slider _playerHookLengthSlider;
        [SerializeField] private TMP_Text _playerDashDistanceText;
        [SerializeField] private TMP_Text _playerTurnSpeedText;
        [SerializeField] private TMP_Text _playerHookLengthText;
        
        [Header("Reference")]
        [SerializeField] private FloatReference _playerDashDistance;
        [SerializeField] private FloatReference _playerTurnSpeed;
        [SerializeField] private FloatReference _playerHookLength;
        [SerializeField] private PlayerStateConfig _basicConfig;
        [SerializeField] private PlayerStateConfig _invisConfig;
        
        private bool _isOn;

        private void Start()
        {
            _isOn = false;
            SetCanvasGroupActivate(_isOn);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _isOn = !_isOn;
                SetCanvasGroupActivate(_isOn);
            }

            _playerDashDistance.Value = _playerDashDistanceOrSpeedSlider.value;
            _playerDashDistanceText.text = Math.Round(_playerDashDistanceOrSpeedSlider.value) + "";
            
            // Remove later; temp hook up to config file
            _basicConfig.DashDistance = _playerDashDistance.Value;
            _invisConfig.DashDistance = _playerDashDistance.Value;

            _playerTurnSpeed.Value = _playerTurnSpeedSlider.value;
            _playerTurnSpeedText.text = Math.Round(_playerTurnSpeedSlider.value) + "";
            
            // Remove later; temp hook up to config file
            _basicConfig.TurnSpeed = _playerTurnSpeed.Value;
            _invisConfig.TurnSpeed = _playerTurnSpeed.Value;

            _playerHookLength.Value = _playerHookLengthSlider.value;
            _playerHookLengthText.text = Math.Round(_playerHookLengthSlider.value) + "";
        }

        private void SetCanvasGroupActivate(bool toActivate)
        {
            _canvasGroup.alpha = toActivate ? 1f : 0f;
            _canvasGroup.blocksRaycasts = toActivate;
            _canvasGroup.interactable = toActivate;
        }
    }
}
