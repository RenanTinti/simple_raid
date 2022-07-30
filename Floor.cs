using UnityEngine;

public class Floor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == 9 || other.gameObject.layer == 13)
            Destroy(other.gameObject);
    }
}
