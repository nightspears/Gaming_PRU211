using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShotgun : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject target;
    Rigidbody2D bulletRB;
    // Start is called before the first frame update
    // Start is called before the first frame update
    public GameObject projectilePrefab; // Reference to your projectile prefab
    public float spreadAngle = 200; // Angle of the shotgun spread
    public float speed = 10f; // Speed of each pellet

    void Start()
    {
        
            float angleOffset = Random.Range(-spreadAngle, spreadAngle);
            bulletRB = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Player");
            Vector2 direction = Quaternion.Euler(0, 0, angleOffset) * target.transform.position - transform.position;
            Vector2 moveDir = (direction).normalized * speed;
            bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
            Destroy(gameObject, 1.5f);
        
    }
}
