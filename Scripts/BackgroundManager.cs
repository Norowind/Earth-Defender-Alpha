using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public float speed;
    public GameObject background;
    private float backgroundWidth;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        backgroundWidth = background.GetComponent<BoxCollider>().size.y * background.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startPosition.z - backgroundWidth)
        {
            transform.position = startPosition;
        }

        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
