using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : MonoBehaviour
{
    Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(0.2604211f, 0.2491516f);
        }
        else
        {
            transform.localScale = new Vector2(-1 * 0.2604211f, 0.2491516f);

        }


    }
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
        var player = target.gameObject.GetComponent<Health>();
        player.TakeDamage(17);
    }
}
