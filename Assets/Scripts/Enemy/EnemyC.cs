using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : MonoBehaviour
{
     int maxDamege = 5;
     int minDamege = 10;
     public Playercontroller player;

     public GameObject other;

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Player"))
            {
              
                InvokeRepeating("DamePlayer", 0, 1f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Player"))
            {

                CancelInvoke("DamePlayer");
            }
        }
    }


    void DamePlayer()
    {
        var player = other.gameObject.GetComponent<Health>();
        player.TakeDamage(25);
    }
}
