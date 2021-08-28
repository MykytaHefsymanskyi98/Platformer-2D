using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //conf param
    [SerializeField] AudioClip coinAddSFX;

    //references
    Animator animator;
    GameManagement gameManagement;

    //states
    bool coinAdded = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameManagement = FindObjectOfType<GameManagement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !coinAdded)
        {
            coinAdded = true;
            AudioSource.PlayClipAtPoint(coinAddSFX, Camera.main.transform.position);
            gameManagement.CoinPlus();
            Destroy(gameObject);           
        }
    }
}
