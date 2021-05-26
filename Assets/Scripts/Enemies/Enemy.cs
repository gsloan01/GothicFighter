using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.5f;
    public float attackSpeed = 1.5f;
    public float range = 1;
    public Animator animator;
    public Vector2 forward { get; set; } = Vector2.right;

    Rigidbody2D rb;
    bool inRange = false;
    bool onGround = true;
    float attackTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attackTimer = attackSpeed;
    }

    void Update()
    {
        float distanceToPlayer = (transform.position - GameController.Instance.player.transform.position).magnitude;
        if (distanceToPlayer <= range)
        {
            rb.velocity = Vector2.zero;
            inRange = true;
            animator?.SetTrigger("InRange");
        }    

        if (!inRange && onGround)
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
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            animator?.SetTrigger("Attack");
            attackTimer = attackSpeed;
        }
    }
}
