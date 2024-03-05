using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float speed;
    public float lineOfSight;
    public float shootingRange;
    public float closeRange;
    public float dashRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    public int maxNormalAttackCount = 0; 
    public Animator animator;

    public int burstRound =10;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(angle>60 || angle<-60){
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }else if(angle<60 && angle>-60){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)
        {
            animator.SetBool("IsAttacking", false);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer<=closeRange&& Time.time > nextFireTime &&transform.position.y +1.5 > player.transform.position.y && player.transform.position.y > transform.position.y-1.5){
            animator.SetBool("IsAttacking", true);
            var dmg = player.GetComponent<Health>();
            dmg.TakeDamage(1);
        }
        else if (distanceFromPlayer <= shootingRange && Time.time > nextFireTime)
        {
            animator.SetBool("IsAttacking", false);
            nextFireTime = Time.time + 1/fireRate;
            for(int i = 0 ; i < burstRound; i++)
            {Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);}
            maxNormalAttackCount++;
            if (maxNormalAttackCount >= Random.Range(7,10))
            {
                StartCoroutine(Dash());
                maxNormalAttackCount = 0;
            }
        }else if (distanceFromPlayer <= dashRange && Time.time > nextFireTime)
        {
            animator.SetBool("IsAttacking", false);
        }
    }
    private IEnumerator Dash()
    {
        float startTime = Time.time;
        while (Time.time < startTime + 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * 4 * Time.deltaTime);
            yield return null;
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
        Gizmos.DrawWireSphere(transform.position, dashRange);
    }
    
}
