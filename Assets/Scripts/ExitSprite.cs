using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSprite : MonoBehaviour
{
    [SerializeField] float levelLoadTime = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            StartCoroutine("ExitCoroutine");
        }
    }

    IEnumerator ExitCoroutine()
    {
        yield return new WaitForSeconds(levelLoadTime);
        LoadNextScene();
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
