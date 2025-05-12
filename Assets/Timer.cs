using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI countdownText;
    private float elapsedTime;
    private float countdownTime = 5f;
    private bool isCountdownComplete = false;

    void Start()
    {
        // Pause the game during the countdown
        Time.timeScale = 0f;

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
        // Use unscaled time for the countdown since timeScale is 0
        countdownTime -= Time.unscaledDeltaTime;
        int seconds = Mathf.CeilToInt(countdownTime);
        countdownText.text = seconds.ToString();

        if (countdownTime <= 0)
        {
            isCountdownComplete = true;
            countdownText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(true);

            // Resume the game
            Time.timeScale = 1f;
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
