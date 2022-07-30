using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject bulletPrefab;
    private GameObject pauseMenu;
    GameObject tempBullet;
    GameManager gameManager;
    public GameObject fuelEffect;
    public GameObject playerExpEffect;
    public Animator anim;
    public Transform shotSpawner;
    public Image fuelUI;
    public Text lifeText;
    public Image goPanel;
    public static int lives = 2;
    public static int stages = 0;
    public int random;
    static float fuel = 60;
    static float maxFuel = 60;
    public float speed;
    public float hForce = 0;
    public bool dead = false;
    public bool canShoot;
    public bool gameOver;
    public bool idle;
    public bool turnLeft;
    public bool turnRight;

    void Start()
    {
        anim = GetComponent<Animator>();
        gameOver = false;
        pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        gameManager = GameManager.gameManager;
        rb = GetComponent<Rigidbody2D>();
        hForce = 0;
    }

    void Update()
    {
        rb.velocity = new Vector2(hForce * speed, rb.velocity.y);

        if(pauseMenu.GetComponent<PauseMenu>().returnHome == 1){
            fuel = maxFuel;
        }

        if(gameOver){
            lives = 2;
            gameManager.ResetData();
        }
    }

    void FixedUpdate()
    {
        StartCoroutine(FuelCountdown());

        fuelUI.fillAmount = (float)fuel / 60;

        if(fuel <= 0)
            Death();
        
        lifeText.text = lives.ToString();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9)
        {
            Death();
        }

        if(other.gameObject.layer == 13){
            Instantiate(fuelEffect);
            fuel += 20;
            if(fuel >= maxFuel)
                fuel = maxFuel;
            Destroy(other.gameObject);
        }

        if(other.gameObject.layer == 14){
            if(stages < 30){
                RandomScene();
                stages++;
            }
            else{
                SceneManager.LoadScene("SC_Boss");
            }
            
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        fuel = maxFuel;
    }
    
    IEnumerator FuelCountdown(){
        if(fuel > 0){
            yield return new WaitForSeconds(1f);
            fuel = fuel - Time.deltaTime;
        }
    }

    public void RandomScene(){
        random = Random.Range(2, 26);
        SceneManager.LoadSceneAsync("SC_" + random);
    }

    void Death(){
        AdMobManager.instance.RequestBanner();
        Instantiate(playerExpEffect, this.transform.position, this.transform.rotation);
        lives--;
        dead = true;
        canShoot = false;
        gameObject.SetActive(false);
        if(lives < 0){
            GameOver();
            lives = 2;
        }
        else{
            Invoke("ReloadScene", 2f);
        }
    }

    public void Left(){
        hForce = -1;
        anim.SetBool("Idle", false);
        anim.SetBool("Right", false);
        anim.SetBool("Left", true);
    }

    public void Right(){
        hForce = 1;
        anim.SetBool("Left", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Right", true);
    }

    public void Stop(){
        hForce = 0;
        anim.SetBool("Left", false);
        anim.SetBool("Right", false);
        anim.SetBool("Idle", true);
    }

    public void Fire(){
        if(tempBullet == null && canShoot){
            tempBullet = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
        }
    }

    void GameOver(){
        AdMobManager.instance.gameOvers++;
        if(AdMobManager.instance.gameOvers >= 2){
            AdMobManager.instance.gameOvers = 0;
            AdMobManager.instance.ShowPopup();
        }
        gameManager.ResetData();
        gameOver = true;
        fuel = maxFuel;
        stages = 0;
        goPanel.gameObject.SetActive(true);
    }

    public void WinLife(){
        lives++;
    }

    public void ResetLives(){
        lives = 2;
    }

    public void ResetStages(){
        stages = 0;
    }
}
