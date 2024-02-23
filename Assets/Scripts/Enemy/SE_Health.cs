using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Health : MonoBehaviour
{
    public int health = 100;
    public int currentHealth;
    public GameObject deathEffect;

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            //Animation
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
