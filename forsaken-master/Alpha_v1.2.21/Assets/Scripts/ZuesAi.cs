using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ZuesAi : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject ZuesProjectile;
    public int zeusHealth;
    int currentHealth;

    public Transform player;

    public Slider healthBar;


    public Animator animator;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        

        timeBtwShots = startTimeBtwShots;
        currentHealth = zeusHealth;
    }

    void Update()
    {

        healthBar.value = currentHealth;

        // if the Zues is far away, move towards Player
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // if Zues is in range stop moving
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(ZuesProjectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }
    public void TakeDamage(int damage)
    {
        SoundManagerScript.PlaySound("enemyHit");
        /*zeusHealth -= damage;*/
        currentHealth -= damage;
        
        animator.SetTrigger("Hit");
        Player.score += 1;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        FollowCamera.won = true;
        SoundManagerScript.PlaySound("Death2");
        Debug.Log("Zeus died.");
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
        this.enabled = false;
    }
}