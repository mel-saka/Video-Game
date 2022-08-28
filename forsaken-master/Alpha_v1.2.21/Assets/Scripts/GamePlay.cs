using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public Slider slider;
    public Transform healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.GetComponent<Image>().color = new Color(0, 1, 0);
    }

    // Update is called once per frame
    //void Update()
    //{
    //if (Player.currentHealth < 61)
    //{
    //    healthBar.GetComponent<Image>().color = new Color(1, 1, 0);
    //}

    //if (Player.currentHealth < 31)
    //{
    //    healthBar.GetComponent<Image>().color = new Color(1, 0, 0);
    //}
    //}
    void Update()
    {
        SetHealth(Player.currentHealth);
        if (Player.currentHealth > 62)
        {
            healthBar.GetComponent<Image>().color = new Color(0, 1, 0);
        }
        if (Player.currentHealth < 61 && Player.currentHealth > 32)
        {
            healthBar.GetComponent<Image>().color = new Color(1, 1, 0);
        }

        if (Player.currentHealth < 31)
        {
            healthBar.GetComponent<Image>().color = new Color(1, 0, 0);
        }
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
