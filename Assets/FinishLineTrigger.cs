using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineTrigger : MonoBehaviour
{
    private bool gameEnded = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameEnded) return;

        if (other.CompareTag("Player"))
        {
            gameEnded = true;
            Debug.Log("Game ended! You reached the finishline and won");
            {
                SceneManager.LoadSceneAsync("WonScreen");
            }

        }
        if (other.CompareTag("Enemy"))
        {
            gameEnded = true;
            Debug.Log("Game ended! Enemy reached the finish line and you lost.");
            SceneManager.LoadSceneAsync("LostScreen");
            
        }
    }
}
