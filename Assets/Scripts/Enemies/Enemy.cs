using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool onRight = false;
    public float speed = 1.5f;
    public float attackSpeed = 1.5f;
    public float range = 1;
    public float health = 1;
    public Animator animator;
    public Vector2 forward { get; set; } = Vector2.right;

    Rigidbody2D rb;
    bool inRange = false;
    bool onGround = true;
    bool isDead = false;
    float attackTimer;
    float deathTimer = 2.5f;
    float knockbackDistance = 0.000001f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attackTimer = attackSpeed;
        if (onRight)
        {
            forward *= -1;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void Update()
    {
        if (!isDead)
        {
            float distanceToPlayer = (transform.position - GameController.Instance.player.transform.position).magnitude;
            if (distanceToPlayer <= range)
            {
                rb.velocity = Vector2.zero;
                inRange = true;
            }    
        
            animator?.SetBool("InRange", inRange);
            //Debug.Log("inRange Bool: " + inRange);
            //Debug.Log("Animator: " + animator?.GetBool("InRange"));

            if (!inRange && onGround)
            {
                rb.velocity = forward * speed;
            }
            else
            {
                Attack();
            }
        }
        else
        {
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Attack()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            animator?.SetTrigger("Attack");
            attackTimer = attackSpeed;
            GameController.Instance.player.OnHurt();
        }
    }

    public void onHit()
    {
        if (!isDead)
        {
            Vector3 knockback = Vector3.zero;
            //knockback.x += (onRight) ? knockbackDistance : -knockbackDistance;
            transform.position += knockback;
            health--;
            if (health <= 0)
            {
                isDead = true;
                animator?.SetTrigger("IsDead");
                rb.velocity = Vector2.zero;
                GameController.Instance.monstersKilled++;
            }
        }
    }
}
