using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI countdownText; // Add a separate TextMeshProUGUI for the countdown
    private float elapsedTime;
    private float countdownTime = 5f; // Countdown starts from 5 seconds
    private bool isCountdownComplete = false;

    void Start()
    {
        // Initialize the countdown text
        countdownText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isCountdownComplete)
        {
            HandleCountdown();
        }
        else
        {
            HandleTimer();
        }
    }

    private void HandleCountdown()
    {
        countdownTime -= Time.deltaTime;
        int seconds = Mathf.CeilToInt(countdownTime);
        countdownText.text = seconds.ToString();

        if (countdownTime <= 0)
        {
            isCountdownComplete = true;
            countdownText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(true);
        }
    }

    private void HandleTimer()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
