using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    [SerializeField] private float _delay = .1f;
    [SerializeField] private string _entireText;
    private string _currentText = "";
    [SerializeField] private Text _target;
    [SerializeField] private AudioSource _textBlip;
    [SerializeField] private int _persistedDuration;

    void OnEnable()
    {
        _target.text = "";
        _currentText = "";
        StartCoroutine(genText(_entireText));
    }


    IEnumerator genText(string textToGen)
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
        _target.text = "";
        textToGen = "";
    }
}
