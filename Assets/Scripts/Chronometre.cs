using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class Chronometre : MonoBehaviour
{
    private float time;
    private bool isStopped;
    public Text timeText; // Reference to the UI Text element
    private Camera mainCamera;

    void Start()
    {
        time = 0;
        isStopped = true;

    }

    void Update()
    {
        if (!isStopped)
        {
            time += Time.deltaTime;

            if (timeText != null)
            {
                Vector3 cameraPos = mainCamera.transform.position;
                timeText.text = $"Score: {time:F2}";
                timeText.transform.position = new Vector3(cameraPos.x + 8, cameraPos.y + 4, 0.1f);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
                Pause();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
                Reset();
            if (Input.GetKeyDown(KeyCode.Escape))
                Continue();
        }
    }

    public void Reset()
    {
        time = 0f;
        isStopped = true;
    }

    public void Continue()
    {
        isStopped = false;
    }

    public void Pause()
    {
        isStopped = true;
    }

    public float GetTime()
    {
        return time;
    }
}