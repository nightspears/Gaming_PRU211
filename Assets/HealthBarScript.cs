using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public Camera cam;
    public Transform target;

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
    transform.rotation = Quaternion.Euler(0, 0, 0);
    transform.position = target.position + new Vector3(0, 1.5f, 0);
    }
}
