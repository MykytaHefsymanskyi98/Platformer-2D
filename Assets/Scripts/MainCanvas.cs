using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvas : MonoBehaviour
{
    float gameSpeed = 1f;
    bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (gameStarted == false)
        {
            Time.timeScale = 0f;
            gameObject.SetActive(true);
            Cursor.visible = true;
        }
    }
    public void StartGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = gameSpeed;
        gameStarted = true;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
