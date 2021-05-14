using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer sr;
    public PlayerDisplay pd;
    

    public float time = 1;
    float timer;

    bool invulnerable = false;

    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
    }


    void Update()
    {
        PlayerTest();
        //PlayerInput();
    }

    void PlayerInput()
    {
        //checks if pressing left / right (can only do one or the other)
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
        //checking jump
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space ))
        {

        }
    }

    /// <summary>
    ///  This method should be able to test if i can flip the player left and right
    /// </summary>
    void PlayerTest()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            pd.FlipPlayer();
            timer = 0;
        }
    }

    /// <summary>
    /// When the player gets hurt, this method is called
    /// </summary>
    void OnHurt()
    {
        //when the player gets hurt
            //set invulnerable to true
            //set a timer for it to 0
                //once timer is done they lose invuln
            //make them flash a color
            //lose health
            //if health is low enough set game state(?)
    }
    void OnAttack()
    {

    }




}
