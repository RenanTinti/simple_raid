using UnityEngine;

public class Boss : MonoBehaviour
{
    private float speed = 4;
    private float hForce;
    public int cannon = 0;
    public GameObject finishPanel;
    GameManager gameManager;

    void Start(){
        gameManager = GameManager.gameManager;
    }
    void Update()
    {
        transform.Translate(new Vector2(speed * hForce * Time.deltaTime, 0));

        if(cannon >= 3){
            gameManager.WinPoints(5000);
            Destroy(gameObject);
            finishPanel.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == 8){
            hForce *= -1;
        }
    }
}
