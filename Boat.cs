using UnityEngine;

public class Boat : MonoBehaviour
{
    Transform playerPosition;
    private float speed = 0;
    private float hForce;
    private bool facingRight;
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        if(playerPosition.gameObject != null && playerPosition.transform.position.x > this.gameObject.transform.position.x)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            facingRight = true;
        }

        else if(playerPosition.gameObject != null && playerPosition.transform.position.x < this.gameObject.transform.position.x)
        {
            Vector3 scale = transform.localScale;
            scale.x *= 1;
            transform.localScale = scale;
            facingRight = false;
        }
    }

    void Update()
    {
        if(facingRight == true)
        {
            hForce = 1;
            transform.Translate(new Vector2(speed * hForce * Time.deltaTime, 0));
        }

        else
        {
            hForce = -1;
            transform.Translate(new Vector2(speed * hForce * Time.deltaTime, 0));
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == 8){
            hForce *= -1;
            Flip();
        }

        if(other.gameObject.layer == 11){
            speed = 4;
        }
    }  
}
