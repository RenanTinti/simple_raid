using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public AudioSource gameOverTheme;
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void TryAgain(){
        SceneManager.LoadScene("SC_1");
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void Quit(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Index");
    }
}
