using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;

    bool enemyDead = false;

    //references
    Player player;
    Rigidbody2D enemy_rb;
    // Start is called before the first frame update
    void Start()
    {
        enemy_rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(IsFacingLeft())
        {
            enemy_rb.velocity = new Vector2(-movementSpeed, 0f);
            
        }
        else
        {
            enemy_rb.velocity = new Vector2(movementSpeed, 0f);
        }
    }
        
    bool IsFacingLeft()
    {
        return transform.localScale.x > 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(Mathf.Sign(enemy_rb.velocity.x), 1f);
    }

   public void Destroyed()
    {
        Destroy(this.gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        //if(collision.gameObject.tag == "Player")
        //{
           // if (player.BoxColliderCollision())
            //{
               // Destroyed();
               // enemyDead = true;
            //}
            //else
            //{
                //return;
            //}
        //}
    //}

    public bool EnemyDead()
    {
        return enemyDead;
    }
}
