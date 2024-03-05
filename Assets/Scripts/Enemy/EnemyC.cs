using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyC : MonoBehaviour
{
     int maxDamege = 5;
     int minDamege = 10;
     public Playercontroller player;

<<<<<<< HEAD
=======
     public GameObject other;

>>>>>>> 1a2afc23ed2aeabb02d5d717a5a2b4d58e55f691
   
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
<<<<<<< HEAD
        int damege = UnityEngine.Random.Range(minDamege, maxDamege);
        player.TakeDame(damege);
       


=======
        var player = other.gameObject.GetComponent<Health>();
        player.TakeDamage(25);
>>>>>>> 1a2afc23ed2aeabb02d5d717a5a2b4d58e55f691
    }
}
