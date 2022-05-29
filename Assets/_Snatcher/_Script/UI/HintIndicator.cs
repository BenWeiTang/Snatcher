using System;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Snatcher
{
    public class HintIndicator : MonoBehaviour
    {
        [Header("UI Component")]
        [SerializeField] private CanvasGroup _hintCanvasGroup;
        [SerializeField] private TMP_Text _hintText;
        [Tooltip("The text this UI will show. Keep it short.")]
        [SerializeField] private string _textToShow;

        [Header("Animation")]
        [Tooltip("The Mode in which the text transitions from transparent to opaque.")]
        [SerializeField] private Ease _enterEaseMode = Ease.Linear;
        [Tooltip("The Mode in which the text transitions from opaque to transparent.")]
        [SerializeField] private Ease _exitEaseMode = Ease.Linear;
        [Tooltip("How long it takes for the text to transition from transparent to fully opaque.")]
        [SerializeField, Range(0f, 2f)] private float _enterDuration = 0.5f;
        [Tooltip("How long it takes for the text to transition from opaque to fully transparent.")]
        [SerializeField, Range(0f, 2f)] private float _exitDuration = 1f;
        

        #region UNITY_METHODS
        private void OnEnable() => _hintText.text = _textToShow;

        private void Start() => _hintCanvasGroup.alpha = 0f;

        private void Reset()
        {
            _enterEaseMode = Ease.Linear;
            _exitEaseMode = Ease.Linear;
            _enterDuration = 0.5f;
            _exitDuration = 1f;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;
            SetCanvasGroupActivate(true);
            _hintText.text = _textToShow;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;
            SetCanvasGroupActivate(false);
        }
        #endregion

        #region PRIVATE_METHODS
        private void SetCanvasGroupActivate(bool toActivate)
        {
            float targetAlpha = toActivate ? 1 : 0;
            if (toActivate)
            {
                _hintCanvasGroup.DOFade(targetAlpha, _enterDuration).SetEase(_enterEaseMode);
            }
            else
            {
                _hintCanvasGroup.DOFade(targetAlpha, _exitDuration).SetEase(_exitEaseMode);
            }
        }
        #endregion
    }
}