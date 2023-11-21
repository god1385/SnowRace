using UnityEngine;

public class InterADCounter : MonoBehaviour
{
    [SerializeField] private float _interDeley;

    private float _counter;

    private void Update()
    {
        _counter += Time.deltaTime;

        if (_counter >= _interDeley)
            ShowInter();
    }

    private void ShowInter()
    {
        _counter = 0;

        //Show inter
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
