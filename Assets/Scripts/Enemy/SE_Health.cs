using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Health : MonoBehaviour
{
    public int health = 100;
    public int currentHealth;
    public GameObject enemy;
    public Animator animator;
    public HealthBarScript healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(health);
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hit");
        if(currentHealth <= 0)
        {
            try
            {
                enemy.GetComponent<EnemyFollow_Shooting>().enabled = false;
            }
            catch
            {
                Debug.Log("EnemyFollow_Shooting not found");   
            }

            try
            {
                enemy.GetComponent<EnemyFollow_shooting2>().enabled = false;
            }
            catch
            {
                Debug.Log("EnemyFollow_shooting2 not found");   
            }
            animator.SetBool("Dead", true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
