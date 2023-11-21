using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  private int _index;

  public void LoadNewScene()
  {
    if (SceneManager.sceneCountInBuildSettings - 1 == SceneManager.GetActiveScene().buildIndex)
    {
      SceneManager.LoadScene(1);
      return;
    }

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}