using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    private const string LevelsLeaderBoard = "LevelsLeaderBoard";

    [SerializeField] private Transform _content;
    [SerializeField] private LeaderBoardPlayerInfo _playerInfoPrefab;
    [SerializeField] private Button _leaderBoardButton;
    [SerializeField] private GameObject _authorizationButton;

    private void OnEnable()
    {
        _authorizationButton.gameObject.SetActive(false);
        Show();
    }

    public void Show()
    {

    }

    public void SetScore()
    {
        int count = PlayerPrefs.GetInt("ComplitedLevels", 1);
        count++;
        PlayerPrefs.SetInt("ComplitedLevels", count);
    }

    public void OnClosetButtonClick()
    {
        _leaderBoardButton.interactable = true;
        gameObject.SetActive(false);
    }

    private void ClearContent()
    {
        if (_content.childCount > 0)
        {
            foreach (Transform child in _content)
            {
                Destroy(child.gameObject);
            }
        }
    }
}