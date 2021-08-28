using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : MonoBehaviour
{
    //conf param
    [SerializeField] float moveSpeedSlow = 1f;
    [SerializeField] float moveSpeedFast = 5f;

    //references
    Rigidbody2D my_rb;
    Animator animator;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        my_rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        Move(Random.Range(moveSpeedSlow, moveSpeedFast), Random.Range(moveSpeedSlow, moveSpeedFast));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Movement Border")
        {
            Move(Random.Range(-moveSpeedSlow, moveSpeedFast), Random.Range(moveSpeedSlow, moveSpeedFast));
        }
        if (collision.gameObject.tag == "Movement Border Right")
        {
            Move(Random.Range(-moveSpeedSlow, -moveSpeedFast), Random.Range(-moveSpeedSlow, moveSpeedFast));
        }
        if (collision.gameObject.tag == "Movement Border Left")
        {
            Move(Random.Range(moveSpeedSlow, moveSpeedFast), Random.Range(-moveSpeedSlow, moveSpeedFast));
        }
        if (collision.gameObject.tag == "Movement Border Top")
        {
            Move(Random.Range(-moveSpeedSlow, moveSpeedFast), Random.Range(-moveSpeedSlow, -moveSpeedFast));
        }
    }

    private void Move(float newMovementSpeedSlow, float newMovementSpeedFast)
    {
        my_rb.velocity = new Vector2(newMovementSpeedSlow, newMovementSpeedFast);
    }
}
