using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;

    public PlayerDisplay playerDisplay;
    public PlayerAttack attackObject;
    PlayerData playerData;
    PlayerAttack currentAttack = null;

    public int health = 5;

    public float jumpForce = 1000f;
    public float invulnTime = 1;
    float invulnerableTimer;

    public float attackTime = 0.1f;
    float attackTimer = 0;
    eDirection facing = eDirection.Right;
    bool invulnerable = false;
    bool onGround = true;


    enum eDirection
    {
        Left, Right
    }

    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //health = playerData.health;
    }
    

    void Update()
    {
        //Check if player is on the ground
        if (rb.velocity.y != 0) onGround = false;
        else onGround = true;
        
        PlayerInput();
    }

    void PlayerAnimations()
    {
        //if no velocity then idle
        //if velocity.y > 0 jump anim
        //if velocity.y < 0 fall anim
    }

    void PlayerInput()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            health--;
            playerDisplay.OnHealthChangeUI();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            health++;
            playerDisplay.OnHealthChangeUI();
        }
        attackTimer += Time.deltaTime;
        //checks if pressing left / right (can only do one or the other)
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && attackTimer >= attackTime)
        {
            OnAttack(eDirection.Left);
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && attackTimer >= attackTime)
        {
            OnAttack(eDirection.Right);
        }
        //checking jump
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space ))
        {
            if(onGround) OnJump();
        }
    }

    /// <summary>
    /// When the player gets hurt, this method is called
    /// </summary>
    public void OnHurt()
    {
        if (invulnerable) return;
        //HURT ANIM
        //when the player gets hurt
        invulnerableTimer += Time.deltaTime;
        if (invulnerableTimer > invulnTime) invulnerable = true; else { invulnerable = false; }
        //make them flash a color
        playerDisplay.OnHealthChangeUI();
        //lose health
        health--;
        //if health is low enough set game state(?)
        if (health <= 0)
        {
            OnDeath();
        }
    }
    void OnAttack(eDirection direction)
    {
        attackTimer = 0;
        if (currentAttack != null) Destroy(currentAttack);
        if (direction != facing) playerDisplay.FlipPlayer(); facing = direction;
        float xOffset = (facing == eDirection.Right) ? 1.5f : -1.5f;

        rb.velocity = Vector2.zero;
        //call attack animation(s)

        currentAttack = Instantiate(attackObject);
        currentAttack.playerData = playerData;
        currentAttack.transform.position = new Vector3(xOffset, transform.position.y, 0);
        Destroy(currentAttack.gameObject, 0.25f);
    }

    void OnJump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
    }

    void OnDeath()
    {
        //player death animation

        //do some restart menu stufffff
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyAttack") && !invulnerable)
        {
            OnHurt();
        }
    }

}
