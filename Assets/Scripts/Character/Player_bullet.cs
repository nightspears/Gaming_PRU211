using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject target;
    [SerializeField]
    private float speed = 10f;
    Rigidbody2D bulletRB;
    private Vector3 mousePos;
        // Start is called before the first frame update
    void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = new Vector2(direction.x, direction.y).normalized.normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer==3)
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            var player = other.gameObject.GetComponent<SE_Health>();
            Destroy(gameObject);
            player.TakeDamage(35);
        }
        if (other.gameObject.tag == "Boss")
        {
            var player = other.gameObject.GetComponent<BossHealth>();
            Destroy(gameObject);
            player.TakeDamage(35);
        }
    }
}
