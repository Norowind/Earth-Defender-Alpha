using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject explosionFire;
    public GameObject explosionSmoke;
    public int hitPoints;
    public int scorePoints;
    private int hits = 0;
    private Score scoreObject;

    // Start is called before the first frame update
    void Awake()
    {
        scoreObject = GameObject.Find("MainManager").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveOn();
        OnGetDeadlyHit();
    }

    public virtual void MoveOn()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        hits += 1;
        Debug.Log("Hit: " + hits);
    }

    private void OnGetDeadlyHit()
    {
        if (hits > hitPoints)
        {
            Destroy(gameObject);
            Instantiate(explosionSmoke, transform.position, gameObject.transform.rotation);
            Instantiate(explosionFire, transform.position, gameObject.transform.rotation);
            scoreObject.actualScore += scorePoints;
        }
    }
}//end of class
