using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerData playerData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject.GetComponent<Enemy>()?.onHit();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //cast as enemy or monster
            collision.gameObject.GetComponent<Enemy>().onHit();
            //remove health
            //knock back a little?

            //monster will deal with dying
        }
    }    
}
