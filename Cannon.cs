using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject ironBallPrefab;
    public Transform shotSpawner;
    GameObject tempBall;
    GameObject boss;
    private float fireRate = 2;
    float nextFire;
    private int hp = 20;
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        StartCoroutine(Wait());
        nextFire = Time.time;
    }

    void Update()
    {
        Shoot();
    }

    public void TookDamage(int damage){
        hp -= damage;
        if(hp <= 0){
            boss.GetComponent<Boss>().cannon++;
            Destroy(gameObject);
        }
    }

    void Shoot(){
        if(Time.time > nextFire){
            fireRate = Random.Range(2, 5);
            tempBall = Instantiate(ironBallPrefab, shotSpawner.transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
    
    IEnumerator Wait(){
        yield return new WaitForSeconds(2f);
    }
}
