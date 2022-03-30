using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public TextMeshProUGUI gameOverText;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            ShowGameOverText();
        }

        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            Debug.Log("RESET");
            ResetScene();
        }
    }

    public void ShowGameOverText()
    {
        gameOverText.gameObject.SetActive(true);
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}//end of class
