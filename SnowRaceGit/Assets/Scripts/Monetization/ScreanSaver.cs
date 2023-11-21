using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreanSaver : MonoBehaviour
{
    private void Start()
    {
        int index = PlayerPrefs.GetInt("SceneIndex");
        
        if (index != 0)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SceneIndex"));
            return;
        }

        SceneManager.LoadScene(1);
    }
}
