using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow_shooting2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public int burstRound;
    public float lineOfSight;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public Rigidbody2D rb;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1/fireRate;
            for(int i = 0 ; i < burstRound; i++)
            {Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);}
        }
        
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
