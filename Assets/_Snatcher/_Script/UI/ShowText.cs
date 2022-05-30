using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace Snatcher
{
    public class ShowText : MonoBehaviour
    {
        [SerializeField] private BoolReference _needsIntro;
        [SerializeField] private float _delay = .1f;
        [SerializeField] private string _entireText;
        [SerializeField] private Text _target;
        [SerializeField] private AudioSource _textBlip;
        [SerializeField] private int _persistedDuration;

        private void OnEnable()
        {
            if (_needsIntro.Value)
            {
                _target.text = "";
                StartCoroutine(GenText(_entireText));
                _needsIntro.Value = false;
            }
        }

        private IEnumerator GenText(string textToGen)
        {
            string currentText = "";
            foreach (char c in textToGen)
            {
                currentText += c;
                _target.text = currentText;
                _textBlip.Play();
                yield return new WaitForSeconds(_delay);
            }

            yield return new WaitForSeconds(_persistedDuration);
            _target.enabled = false;
            _target.text = "";
        }
    }
}

