using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConsistantObjects : MonoBehaviour
{

    [SerializeField] GameObject coins;
    static ConsistantObjects instance = null;
    int startngSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        if(!instance)
        {
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            startngSceneIndex = SceneManager.GetActiveScene().buildIndex;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(startngSceneIndex != SceneManager.GetActiveScene().buildIndex)
        {
            instance = null;
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(gameObject);
        }
    }
    public void DestroyConsistentObjects()
    {
        Destroy(this.gameObject);
    }
}
