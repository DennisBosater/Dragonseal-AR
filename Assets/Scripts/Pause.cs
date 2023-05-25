using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public AudioSource musicSource;
    public Button pauseButton;
    public Button unpauseButton;

    private GameObject[] dragons;

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseMusic);
        unpauseButton.onClick.AddListener(UnpauseMusic);
    }

    private void PauseMusic()
    {
        musicSource.Pause();
        DestroyDragons();
    }

    private void UnpauseMusic()
    {
        musicSource.UnPause();
    }

    private void DestroyDragons()
    {
        dragons = GameObject.FindGameObjectsWithTag("Dragon");

        foreach (GameObject dragon in dragons)
        {
            Destroy(dragon);
        }
    }
}
