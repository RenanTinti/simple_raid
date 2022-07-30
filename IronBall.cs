using UnityEngine;

public class IronBall : MonoBehaviour
{
    GameObject target;
    Vector2 moveDirection;
    private Rigidbody2D rb;
    private float speed = 6;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity =  new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 4f);  
    }
}
