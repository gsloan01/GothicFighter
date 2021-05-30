using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerData playerData;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //cast as enemy or monster
            collision.gameObject.GetComponent<Enemy>().onHit();
            Debug.Log("Enemy has been hit");
                //remove health
                //knock back a little?

            //monster will deal with dying
        }
    }
}
