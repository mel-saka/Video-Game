using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public Transform dropPoint;
    public GameObject theDrops;

    public Rigidbody2D rb;
    public Transform player;

    public bool drops;



    private void Start()
    {
        currentHealth = maxHealth;
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }

    public void TakeDamage(int damage)
    {
        SoundManagerScript.PlaySound("enemyHit");
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        /*rb.AddForce(player.position * 1000f);*/
        StartCoroutine(Knockback(3, 1000, this.transform));
        if (currentHealth <= 0)
        {
            Player.score += 1;
            Die();
        }
    }
    
    public IEnumerator Knockback(float knockBackDuration, float power, Transform obj)
    {
        float timer = 0;

        while(knockBackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position);
            rb.AddForce(direction * power);
        }
        Debug.Log("Knockback");

        yield return 0;
    }


    void Die()
    {
        SoundManagerScript.PlaySound("Death1");
        animator.SetBool("isDead", true);
        //Debug.Log("Enemy Died");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyControl>().enabled = false;
        //Destroy enemy prefab
        Destroy(gameObject);
        this.enabled = false;
        if (drops) Instantiate(theDrops, dropPoint.position, dropPoint.rotation);
      
    }

    
}