using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float countdownTime = 100f;

    void Update()
    {
        countdownTime -= Time.deltaTime;

        // Check if countdown is finished
        if (countdownTime <= 0f)
        {
            countdownTime = 0f;
            // Perform any actions you want when the countdown reaches zero

            // For example, stop the timer or trigger an event
            // StopTimer();
            // OnCountdownFinished.Invoke();
        }

        // Update the countdown text
        countdownText.text = countdownTime.ToString("0");
    }
}