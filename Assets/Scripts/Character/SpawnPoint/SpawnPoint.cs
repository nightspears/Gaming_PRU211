using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Teleport the player to the spawn point's position
            player.transform.position = transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
