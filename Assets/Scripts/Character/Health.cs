using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public DeathMenu deathMenu;
    public int maxHealth = 100;
    public int currentHealth;
   

    public HealthBarScript healthBar;
    // Start is called before the first frame update
    void Start()
    {
        setHealth();
    }
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0  )
        {
            deathMenu.Death();
        }
        
    }
    void Update()
    {

    }
    public void setHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

 
}
    


