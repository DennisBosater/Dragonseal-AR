using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRetry : MonoBehaviour
{
    public void Restart()
    {
        // Get the current active scene's name
        string sceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene(sceneName);
    }
}
