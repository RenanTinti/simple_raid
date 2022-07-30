using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public GameObject finishGame;
    GameManager gameManager;
    GameObject ship;
    private bool gameOver;
    private int random;
    public int returnHome = 0;
    void Start()
    {
        finishGame.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue(){
        finishGame.SetActive(false);
        Time.timeScale = 1f;
        random = Random.Range(2, 26);
        SceneManager.LoadSceneAsync("SC_" + random);
    }

    public void Home(){
        ship = GameObject.FindGameObjectWithTag("Player");
        ship.GetComponent<Ship>().ResetLives();
        returnHome = 1;
        Time.timeScale = 1f;
        gameManager = GameManager.gameManager;
        gameManager.ResetData();
        SceneManager.LoadScene("Index");
    }
}
