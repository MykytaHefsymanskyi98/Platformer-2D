using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RestartThisLevel()
    {
        Destroy(FindObjectOfType<ConsistantObjects>().gameObject);
        Destroy(FindObjectOfType<GameManagement>().gameObject);
        SceneManager.LoadScene(currentSceneIndex);
        Cursor.visible = false;
    }
    public void LoadMainMenu()
    {
        Destroy(FindObjectOfType<ConsistantObjects>().gameObject);
        Destroy(FindObjectOfType<GameManagement>().gameObject);
        SceneManager.LoadScene(0);
        Cursor.visible = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
