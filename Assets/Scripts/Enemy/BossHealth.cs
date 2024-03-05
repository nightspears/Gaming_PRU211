using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 500;
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

    // Update is called once per frame
     public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hit");
        if(currentHealth <= 0)
        {
            try
            {
                enemy.GetComponent<BossBehavior>().enabled = false;
            }
            catch
            {
                Debug.Log("BossBehavior not found");   
            }
            animator.SetBool("Dead", true);
        }
    }
}
