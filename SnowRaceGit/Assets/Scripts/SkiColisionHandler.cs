using UnityEngine;

public class SkiColisionHandler : MonoBehaviour
{
    [SerializeField] private AudioHandler _audioHandler;
    
    private float _normalTimeScale;
    private Player _player;

    private bool _isOpenSkiRewardAD = false;

    public bool IsOpenSkiRewardAD => _isOpenSkiRewardAD;

    private void Start()
    {
        _normalTimeScale = Time.timeScale;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out Player player))
        {
            _player = player;
            _player.UseSki();
            gameObject.SetActive(false);
        }
    }
}

