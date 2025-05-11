using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineTrigger : MonoBehaviour
{
    private bool gameEnded = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameEnded) return;

        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            gameEnded = true;
            Debug.Log("Game ended! " + other.tag + " reached the finish line.");
            {
                SceneManager.LoadSceneAsync("StartMenu");
            }

        }
    }
}
