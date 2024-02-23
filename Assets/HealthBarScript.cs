using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.identity;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        if (slider.value > slider.maxValue)
        {
            slider.value = slider.maxValue;
        }
    }


    public void SetHealth(int health)
    {
        slider.value = health;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
