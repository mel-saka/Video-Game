using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public static int maxHealth = 100;
    public static int currentHealth;
    public static GameObject bow;
    public static GameObject sword;
    public static GameObject spartanHelm;
    public static GameObject medusaHelm;
    public GamePlay healthBar;

    public static int score = 0;
    /*public static GameObject health;*/

    private void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);

        bow = GameObject.FindGameObjectWithTag("Bow");
        sword = GameObject.FindGameObjectWithTag("Sword");
        spartanHelm = GameObject.FindGameObjectWithTag("spartanHelm");
        medusaHelm = GameObject.FindGameObjectWithTag("medusaHelm");
        /*health = GameObject.FindGameObjectWithTag("healthBar");*/
        toggleBowOff();
        toggleSwordOff();
 
    }

    public void TakeDamage(int damage)
    {
        SoundManagerScript.PlaySound("playerHit");
        currentHealth -= damage;
        animator.SetTrigger("Hit");
        healthBar.SetHealth(currentHealth);
        //animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public static void toggleBowOn()
    {
        bow.SetActive(true);
        medusaHelm.SetActive(true);
    }

    public static void toggleBowOff()
    {

        bow.SetActive(false);
        medusaHelm.SetActive(false);

    }

    public static void toggleSwordOn()
    {
        
        sword.SetActive(true);
        spartanHelm.SetActive(true);
    }

    public static void toggleSwordOff()
    {
        sword.SetActive(false);
        spartanHelm.SetActive(false);
    }

   

    //Vector3.Distance(target.position, transform.position) <= range)
    void OnCollisonEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            other.GetComponent<Player>().TakeDamage(15);
            
            Debug.Log("Player got hit");
            GetComponent<MedusaProjectile>().DestroyProjectile();
        }
    }


    void Die()
    {
        //animator.SetBool("isDead", true);
        //Debug.Log("Enemy Died");
        // GetComponent<Collider2D>().enabled = false;
        //GetComponent<EnemyControl>().enabled = false;
        //this.enabled = false;
        Destroy(this.gameObject);
    }
}
