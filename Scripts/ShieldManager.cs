using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShieldManager : MonoBehaviour
{
    public TextMeshProUGUI shieldHitPointsUI;
    public GameObject gameManager;
    private GameManager gameManagerScript;

    private int shieldHitPoints;

    public bool canCount;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();

        canCount = true;

        shieldHitPoints = 100;
    }

    // Update is called once per frame
    void Update()
    {
        shieldHitPointsUI.text = "Earth Shield: " + shieldHitPoints;

        if (shieldHitPoints <= 0)
        {
            shieldHitPoints = 0;

            canCount = false;

            gameManagerScript.gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && canCount)
        {
            shieldHitPoints = shieldHitPoints - other.gameObject.GetComponent<Enemy>().scorePoints;
        }
    }
}//end of class
