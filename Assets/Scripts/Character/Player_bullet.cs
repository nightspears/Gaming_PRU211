using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject target;
    public float speed;
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
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("tag: "+other.gameObject.tag);
        Debug.Log("layer: "+other.gameObject.layer);
        if (other.gameObject.layer==3)
        {
            Destroy(gameObject);
            Debug.Log(other.gameObject.tag);
        }
        if (other.gameObject.tag == "Enemy")
        {
            var player = other.gameObject.GetComponent<SE_Health>();
            Destroy(gameObject);
            player.TakeDamage(35);
            Debug.Log("Hit");
        }
    }
}
