using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zeusHealth : MonoBehaviour
{
    ZuesAi zeus;
    public Slider slider;
    int currentHealth;
    public Transform healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = zeus.zeusHealth;
    }

    void Update()
    {
        SetHealth(zeus.zeusHealth);

    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;

    }
}
