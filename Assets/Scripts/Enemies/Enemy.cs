using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.5f;
    public float range = 1;

    public Vector2 forward { get; set; } = Vector2.right;

    Rigidbody2D rb;
    bool inRange = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceToPlayer = (transform.position - GameController.Instance.player.transform.position).magnitude;
        if (distanceToPlayer <= range)
        {
            rb.velocity = Vector2.zero;
            inRange = true;
        }    

        if (!inRange)
        {
            rb.velocity = forward * speed;
        }
        else
        {
            Attack();
        }
    }

    void Attack()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
