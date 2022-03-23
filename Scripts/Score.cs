using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI m_score;
    public int actualScore;

    // Start is called before the first frame update


    void Start()
    {
        actualScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_score.text = "Score: " + actualScore;
    }
}
