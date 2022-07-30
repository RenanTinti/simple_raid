using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text pointsText;
    public Text recordText;
    GameObject ship;
    public GameObject lifeEffect;
    public static int count;
    public static int points;
    public static GameManager gameManager;

    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start(){
        ship = GameObject.FindGameObjectWithTag("Player");
        recordText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update(){
        pointsText.text = points.ToString();

        if(points > PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", points);
        }
    }

    public void WinCount(){
        count++;
        if(count >= 100){
            ship.GetComponent<Ship>().WinLife();
            Instantiate(lifeEffect);
            count = 0;
        }  
    }

    public void ResetData(){
        points = 0;
        count = 0;
    }

    public void WinPoints(int receivedPoints){
        points += receivedPoints;
    }
}

