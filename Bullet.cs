using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int count;
    private float speed = 55;
    private int boatPoints = 100;
    private int chopperPoints = 200;
    private int planePoints = 500;
    private int fuelPoints = 50;
    GameManager gameManager;
    public GameObject expEffect;
    public GameObject bigExpEffect;
    public GameObject vBigExpEffect;

    void Start()
    {
        Destroy(gameObject, 0.4f);
        gameManager = GameManager.gameManager;
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Boat":
            Instantiate(bigExpEffect, this.transform.position, this.transform.rotation);
                gameManager.WinPoints(boatPoints);
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
            case "Chopper":
            Instantiate(expEffect, this.transform.position, this.transform.rotation);
                gameManager.WinPoints(chopperPoints);
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
            case "Plane":
            Instantiate(expEffect, this.transform.position, this.transform.rotation);
                gameManager.WinPoints(planePoints);
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
            case "Fuel":
                Instantiate(expEffect, this.transform.position, this.transform.rotation);
                gameManager.WinPoints(fuelPoints);
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
            case "Wall":
                Destroy(gameObject);
                break;
            case "Roof":
                Destroy(gameObject);
                break;
            case "Cannon":
                Instantiate(expEffect, this.transform.position, this.transform.rotation);
                other.gameObject.GetComponent<Cannon>().TookDamage(1);
                Destroy(gameObject);
            break;
        }
        if(other.gameObject.layer == 9){
            gameManager.WinCount();
        }
    }
}
