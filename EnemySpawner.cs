using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject boat;
    public GameObject chopper;
    public GameObject plane;
    private int random;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == 11){
            random = Random.Range(1, 4);

            switch(random){
                case 1:
                    Instantiate(boat, gameObject.transform.position, gameObject.transform.rotation);
                break;
                case 2:
                    Instantiate(chopper, gameObject.transform.position, gameObject.transform.rotation);
                break;
                case 3:
                    Instantiate(plane, gameObject.transform.position, gameObject.transform.rotation);
                break;
            }
        }
    }
}
