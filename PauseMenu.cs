using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    GameManager gameManager;
    GameObject ship;
    public bool gameOver;
    public int returnHome = 0;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(){
        ship = GameObject.FindGameObjectWithTag("Player");
        ship.GetComponent<Ship>().ResetLives();
        ship.GetComponent<Ship>().ResetStages();
        returnHome = 1;
        Time.timeScale = 1f;
        gameManager = GameManager.gameManager;
        gameManager.ResetData();
        SceneManager.LoadScene("Index");
    }
}