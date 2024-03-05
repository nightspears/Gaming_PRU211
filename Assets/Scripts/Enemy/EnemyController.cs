using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
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
            transform.localScale = new Vector2(-1* 0.2604211f, 0.2491516f);

        }
       
       
    }
}
