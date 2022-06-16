using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float timBetweenShotsDefault;
    public float bulletSpeedDefault;
    public float bulletSpeedBooster;

    private float horizontalInput, verticalInput;
    private float horizontalBorder = 66.0f;
    private float verticalBorderBottom = -8.0f;
    private float verticalBorderTop = 60.0f;

    public GameObject[] bullet;
    private GameObject leftGun;
    private GameObject rightGun;
    public GameObject explosionFire;
    public GameObject explosionSmoke;
    public GameObject gameManager;
    private GameManager gameManagerScript;

    public bool canShoot;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();

        isDead = false; 

        leftGun = GameObject.Find("LeftGun");
        rightGun = GameObject.Find("RightGun");

        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement system
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (!gameManagerScript.gameOver)
        {
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime, Space.World);
            transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime, Space.World);
        }

        //Set borders for the player
        if (transform.position.x > horizontalBorder)
        {
            transform.position = new Vector3(horizontalBorder, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -horizontalBorder)
        {
            transform.position = new Vector3(-horizontalBorder, transform.position.y, transform.position.z);
        }
        else if (transform.position.z < verticalBorderBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, verticalBorderBottom);
        }
        else if (transform.position.z > verticalBorderTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, verticalBorderTop);
        }

        //Player shooting
        if (Input.GetKey(KeyCode.Mouse0) && canShoot && !gameManagerScript.gameOver)
        {
            StartCoroutine(Shoot());
        }
    }
    private IEnumerator Shoot()
    {
        Instantiate(bullet[0], leftGun.transform.position, leftGun.transform.rotation);
        Instantiate(bullet[0], rightGun.transform.position, leftGun.transform.rotation);

        canShoot = false;

        yield return new WaitForSecondsRealtime(timBetweenShotsDefault);

        canShoot = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isDead = true;
            gameManagerScript.gameOver = true;

            Instantiate(explosionSmoke, transform.position, gameObject.transform.rotation);
            Instantiate(explosionFire, transform.position, gameObject.transform.rotation);

            Destroy(gameObject);
        }
    }
}//end of class
