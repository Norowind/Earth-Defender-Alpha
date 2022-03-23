using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float verticalInput;
    private float horizontalBorder = 66.0f;
    private float verticalBorderBottom = -8.0f;
    private float verticalBorderTop = 60.0f;
    public GameObject[] bullet;
    private GameObject leftGun;
    private GameObject rightGun;
    public GameObject explosionFire;
    public GameObject explosionSmoke;
    public float timBetweenShotsDefault;
    public float bulletSpeedDefault;
    private bool canShoot;
    public float bulletSpeedBooster;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
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

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

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
        if (Input.GetKey(KeyCode.Space) && canShoot)
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
            Destroy(gameObject);
            Instantiate(explosionSmoke, transform.position, gameObject.transform.rotation);
            Instantiate(explosionFire, transform.position, gameObject.transform.rotation);
            isDead = true;
        }
    }
}//end of class
