using UnityEngine;

public class Cam : MonoBehaviour
{
    Ship ship;
    public GameObject boostEffect;
    public GameObject breakEffect;
    private float speed = 4;
    private float vForce;

    void Start(){
        ship = gameObject.GetComponentInChildren<Ship>();
    }
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if(ship.dead)
            speed = 0;
    }

    public void Boost(){
        speed *= 2f;
        Instantiate(boostEffect);
    }

    public void Break(){
        speed *= 0.5f;
        Instantiate(breakEffect);
    }

    public void Normal(){
        speed = 4;
    }
}
