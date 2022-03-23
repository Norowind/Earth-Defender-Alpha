using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;
    private float topBorder = 70.0f;
    public GameObject hitEffect;
    private Rigidbody bulletRb;

    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.Find("Player").GetComponent<PlayerController>().bulletSpeedDefault + GameObject.Find("Player").GetComponent<PlayerController>().bulletSpeedBooster;
        bulletRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z > topBorder)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

    }
}//end of class
