using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _noThanksShowDelay;
    [SerializeField] private Button _noThanks;

    public event Action LevelComplite;

    private void Start()
    {
        _noThanks.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _joystick.gameObject.SetActive(false);
        StartCoroutine(NoThanksShow());
    }

    private IEnumerator NoThanksShow()
    {
        yield return new WaitForSeconds(_noThanksShowDelay);
        _noThanks.gameObject.SetActive(true);
    }

    public void ChangeTetx(string text)
    {
        _text.text = text;
    }
    
    private void OnOpen()
    {
        Constants.IsWatchAdd = true;
        AudioListener.volume = 0;
    }

    private void OnClose(bool bol)
    {
        AudioListener.volume = 1;
        Constants.IsWatchAdd = false;
        
    }

    private void OnError(string error)
    {
        AudioListener.volume = 1;
        Constants.IsWatchAdd = false;
    }
}