using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplay : MonoBehaviour
{
    
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Flips the player's Sprite to face the opposite direction (left, right)
    /// </summary>
    void FlipPlayer()
    {
        sr.flipY = !sr.flipX;
    }

    void HurtColoration()
    {
        //Make the player flash a color
        //could do this in an animation
    }
}
