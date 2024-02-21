using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randoming : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        int rand = UnityEngine.Random.Range(0, 2);
        if(rand == 1){
            Destroy(gameObject);
        }
    }
}
