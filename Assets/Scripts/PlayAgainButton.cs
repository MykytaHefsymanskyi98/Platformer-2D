using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    GameManagement gameManagement;

    public void PlayAgain()
    {
        if(FindObjectOfType<GameManagement>())
        {
            gameManagement = FindObjectOfType<GameManagement>();
            gameManagement.DestroyGameManager();
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
            
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
