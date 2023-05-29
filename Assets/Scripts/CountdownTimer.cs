using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float countdownTime = 100f;
    public GameObject deactivateDragonPortal;
    public GameObject deactivateUIHud;
    public GameObject activateUIWinstate;
    public TextMeshProUGUI scoreGame;
    public TextMeshProUGUI scoreWinstate;

    private bool countdownFinished = false;
    private GameObject[] dragons;

    // Add a reference to the audio source component
    public AudioSource musicSource;

    void Update()
    {
        if (countdownFinished)
            return;

        countdownTime -= Time.deltaTime;

        // Check if countdown is finished
        if (countdownTime <= 0f)
        {
            countdownTime = 0f;
            countdownFinished = true;

            // Perform actions when the countdown reaches zero
            DeactivateDragonPortal();
            DestroyDragons();
            DeactivateUIHud();
            ActivateObject();
            TransferTextValue();
            StopMusic(); // Stop playing the music
        }

        // Update the countdown text
        countdownText.text = countdownTime.ToString("0");
    }

    private void DeactivateDragonPortal()
    {
        if (deactivateDragonPortal != null)
            deactivateDragonPortal.SetActive(false);
    }

    private void DestroyDragons()
    {
        dragons = GameObject.FindGameObjectsWithTag("Dragon");

        foreach (GameObject dragon in dragons)
        {
            Destroy(dragon);
        }
    }

    private void DeactivateUIHud()
    {
        if (deactivateUIHud != null)
            deactivateUIHud.SetActive(false);
    }

    private void ActivateObject()
    {
        if (activateUIWinstate != null)
            activateUIWinstate.SetActive(true);
    }

    private void TransferTextValue()
    {
        if (scoreGame != null && scoreWinstate != null)
        {
            scoreWinstate.text = scoreGame.text;
        }
    }

    // Function to stop playing the music
    private void StopMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}
