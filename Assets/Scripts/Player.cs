using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //conf param
    [SerializeField] private float runningSpeed = 1f;
    [SerializeField] private float climbingSpeed = 4f;
    [SerializeField] private float jumpingForce = 20f;

    //states
    bool isAlive = true;
    private bool isJumping;
    bool boxColliderCollision = false;

    //references
    Animator animator;
    Rigidbody2D rigidBody;
    CapsuleCollider2D colliderPlayer;
    float gravityScaleFlag;
    BoxCollider2D boxCollider;
    GameManagement gameManagement;
    EnemyMovement enemy;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        colliderPlayer = GetComponent<CapsuleCollider2D>();
        gravityScaleFlag = rigidBody.gravityScale;
        boxCollider = GetComponent<BoxCollider2D>();
        gameManagement = FindObjectOfType<GameManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive)
        {
            return;
        }
        else
        {
            Running();
            Climbing();
            FlipSprite();
            Jumping();
        } 
    }

    private void Running()
    {        
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runningSpeed, rigidBody.velocity.y);
        rigidBody.velocity = playerVelocity;
        RunningState();     
    }

    void RunningState()
    {
        if((Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon) && IsGrounded())
        {
             animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    
    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
        }
    }

    private void Climbing()
    {     
        if (!boxCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            animator.SetBool("isClimbing", false);
            rigidBody.gravityScale = gravityScaleFlag;
            return;
        }
        else
        {
            ClimbingState();
            float controlThrowClimbing = Input.GetAxis("Vertical");
            Vector2 playerVelocityClimbing = new Vector2(rigidBody.velocity.x, controlThrowClimbing * climbingSpeed);
            rigidBody.velocity = playerVelocityClimbing;
            rigidBody.gravityScale = 0f;
           
        }        
    }

    private void ClimbingState()
    {
        bool playerHasVerticalSpeed = Mathf.Abs(rigidBody.velocity.y) > Mathf.Epsilon;
        if (playerHasVerticalSpeed)
        {
            animator.SetBool("isClimbing", true);
        }
    }

    private void Jumping()
    { 
        if (IsGrounded())
        {
            if (Input.GetKeyDown("space"))
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y + jumpingForce);
            }
            else
            {
                return;
            }
        }
    }   
    private bool IsGrounded()
    {  
        if(boxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return true;
        }
        else
        {
            return false;
        }
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(boxCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
                //boxColliderCollision = true;
                Destroy(collision.gameObject);
        }
        else if(boxCollider.IsTouchingLayers(LayerMask.GetMask("Spike", "Enemy Bat")) && isAlive)
        {
            gameManagement.ProcessPlayerDamageLevel();
        }
        else if (colliderPlayer)
        {
            if (colliderPlayer.IsTouchingLayers(LayerMask.GetMask("Enemy", "Spike", "Enemy Bat")) && isAlive)
            {
                gameManagement.ProcessPlayerDamageLevel();
            }
        }
    }
    public void SetIsAlive(bool isAliveVariable)
    {
        if(isAliveVariable == false)
        {
            isAlive = false;
        }
        else
        {
            isAlive = true;
        }     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(colliderPlayer.IsTouchingLayers(LayerMask.GetMask("Water Going Up", "Water")))
        {
            gameManagement.ProcessPlayerDamageLevel();
        }
    }
    
    public bool BoxColliderCollision()
    {
        return boxColliderCollision;
    }
}
