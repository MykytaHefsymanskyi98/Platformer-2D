using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    GameManagement gameManagement;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        ShowScore();
    }

    void ShowScore()
    {
        gameManagement = FindObjectOfType<GameManagement>();
        scoreText = GetComponent<Text>();
        
        if (!FindObjectOfType<GameManagement>())
        {
            return;
        }
        else
        {
            scoreText.text = gameManagement.CurrentScore().ToString();
        }
    }
}
