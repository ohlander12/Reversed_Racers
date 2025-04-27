using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("AllTiles");
        audioManager.PlaySFX(audioManager.Play);
    }

    public void QuitGame()
    {
        Application.Quit();
        audioManager.PlaySFX(audioManager.Button);
    }
}
