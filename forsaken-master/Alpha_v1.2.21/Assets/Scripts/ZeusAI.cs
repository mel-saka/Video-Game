using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZeusAI : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public int zeusHealth = 1000;
    int currentHealth;

    public GameObject ZeusProjectile;


    public Transform player;

    
    public Rigidbody2D rb;



    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

        }

        timeBtwShots = startTimeBtwShots;
        currentHealth = zeusHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 relativePos = player.position - transform.position;
            Vector3 relativeAngle = relativePos.normalized;
            float angle = Vector3.Angle(relativeAngle, transform.forward);
            Quaternion rotation = Quaternion.AngleAxis(angle - 212.5f, Vector3.forward);

            //// if the Medusa is far away, move towards Player
            //if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            //{
            //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            //    // if medusa is in range stop moving
            //}
            //else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            //{
            //    transform.position = this.transform.position;
            //}
            //else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            //{
            //    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            //}
           
            /*            Debug.Log("Medusa angle : " + relativePos.normalized.z);*/

            if (timeBtwShots <= 0)
            {
                Instantiate(ZeusProjectile, transform.position, rotation);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        SoundManagerScript.PlaySound("enemyHit");
        currentHealth -= damage;


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