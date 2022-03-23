using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float zSpawnPoint = 90.0f;
    private float leftSpawnLimit = -62.0f;
    private float rightSpawnLimit = 62.0f;
    private float minSpawnTime = 1.0f;
    private float maxSpawnTime = 5.0f;

    public GameObject[] asteroids;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroids", 1.0f, Random.Range(minSpawnTime, maxSpawnTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAsteroids()
    {
        Instantiate(asteroids[Random.Range(0,asteroids.Length)], new Vector3(Random.Range(leftSpawnLimit, rightSpawnLimit), transform.position.y, zSpawnPoint), Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));
    }
}//end of class
