using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deathMenuUI;
    //public HealthBarScript healthBar;
    public Health health;
    void Start()
    {
        
    }
    public void Revival( )
    {
        health.setHealth();
        deathMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Main Menu");
    }
    public void Death()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log(" đã show menu 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
