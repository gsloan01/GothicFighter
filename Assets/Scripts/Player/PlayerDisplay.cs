using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{

    public List<Image> healthSlots = new List<Image>();
    public int startRedVal;
    int hurtRedVal;
    PlayerController player;
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        hurtRedVal = startRedVal - 50;
        player = GetComponent<PlayerController>();
        
    }
    private void Update()
    {
        OnHealthChangeUI();
    }
    /// <summary>
    /// Flips the player's Sprite to face the opposite direction (left, right)
    /// </summary>
    public void FlipPlayer()
    {
        sr.flipX = !sr.flipX;
    }

    public void HurtColoration()
    {
        //Make the player flash a color
        
        
        //could do this in an animation
    }

    public void NormalColoration()
    {
        //return color to normal
        sr.color = Color.white;
    }

    public void OnHealthChangeUI()
    {
        if (player.health > 5 || player.health < 0) return;
        Color start = new Color(startRedVal, 0, 0);
        Color hurt = new Color(hurtRedVal, 0, 0);
        //set the amount of health you have
        for (int i = 0; i < player.health; i++)
        {
            healthSlots[i].color = start;
        }
        for (int i = healthSlots.Count-1; i >= player.health-1; i--)
        {
            healthSlots[i-1].color = hurt;
        }
    }
}
