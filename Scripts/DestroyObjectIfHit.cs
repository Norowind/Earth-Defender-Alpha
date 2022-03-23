using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectIfHit : MonoBehaviour
{
    public int hitPoints;
    private int hits = 0;

    public GameObject explosionSmoke;
    public GameObject explosionFire;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hits > hitPoints)
        {
            Destroy(gameObject);
            Instantiate(explosionSmoke, transform.position, gameObject.transform.rotation);
            Instantiate(explosionFire, transform.position, gameObject.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hits += 1;
        Debug.Log("Hit: " + hits);
    }
}//end of class
