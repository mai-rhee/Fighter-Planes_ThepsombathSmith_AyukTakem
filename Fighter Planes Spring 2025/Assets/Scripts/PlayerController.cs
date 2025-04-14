using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{

    public int lives;
    private float speed;

    private GameManager gameManager;

    private float horizontalInput;
    private float verticalInput;

    private bool shieldActive = false;

    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public GameObject shieldPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lives = 3;
        speed = 5f;
        gameManager.ChangeLivesText(lives);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

 
    public void LoseALife()
    {
        if (shieldActive == true) 
        {
            shieldActive = false;
            gameManager.PlaySound(2);
            shieldPrefab.SetActive(false);
            return;
        }
        //lives = lives - 1;
        //lives -= 1;
        else if (shieldActive == false)
        {
            lives--;
            shieldPrefab.SetActive(false);
            gameManager.ChangeLivesText(lives);

            Debug.Log("Lost a life. Lives left: " + lives);
        }

         if (lives == 0)
         {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.GameOver();
            Destroy(this.gameObject);
            return;
         }

}

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.CompareTag("PowerUp"))
        {
            Destroy(whatDidIHit.gameObject);
            gameManager.PlaySound(1);
            //Shield
            shieldActive = true;
            shieldPrefab.SetActive(true);
        }

    }

    void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, 
            verticalInput, 0) * Time.deltaTime * speed);

        float horizontalScreenSize = gameManager.horizontalScreenSize;
        float verticalScreenSize = gameManager.verticalScreenSize;

        if (transform.position.x <= -horizontalScreenSize || transform.position.x > horizontalScreenSize)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if (transform.position.y <= -3.5f)
        {
            transform.position = new Vector3(transform.position.x, -3.5f, 0);
        }
        else if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

    }
}
