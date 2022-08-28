using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public static int currentHealth;
    public static GameObject bow;
    public static GameObject sword;


    private void Start()
    {
        currentHealth = maxHealth;

        bow = GameObject.FindGameObjectWithTag("Bow");
        sword = GameObject.FindGameObjectWithTag("Sword");
        toggleBowOff();
        toggleSwordOff();
        toggleSwordOn();

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hit");

        //animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public static void toggleBowOn()
    {

        bow.SetActive(true);


    }

    public static void toggleBowOff()
    {

        bow.SetActive(false);

    }

    public static void toggleSwordOn()
    {

        sword.SetActive(true);

    }

    public static void toggleSwordOff()
    {

        sword.SetActive(false);
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