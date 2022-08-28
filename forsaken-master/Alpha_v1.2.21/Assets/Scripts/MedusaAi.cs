using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaAi : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public int medusaHealth = 100;
    int currentHealth;

    public GameObject MedusaProjectile;

    public Animator animator;

    public Transform player;

    public Transform dropPoint;
    public GameObject theDrops;
    public Rigidbody2D rb; 

    public bool drops;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        }

        timeBtwShots = startTimeBtwShots;
        currentHealth = medusaHealth;
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
            animator.SetFloat("MoveX", relativePos.x);
/*            Debug.Log("Medusa angle : " + relativePos.normalized.z);*/

            if (timeBtwShots <= 0)
            {
                Instantiate(MedusaProjectile, transform.position, rotation);
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

        animator.SetTrigger("Hit");
        
        if (currentHealth <= 0)
        {
            Die();
            Player.score += 3;
        }
    }
    void Die()
    {
        SoundManagerScript.PlaySound("Death2");
        Debug.Log("Medusa died.");
        Destroy(gameObject);
        this.enabled = false;
        if (drops) Instantiate(theDrops, dropPoint.position, dropPoint.rotation);
        //Destroy(GameObject.FindWithTag("MedusaSS"), 10);
        //Destroy(GameObject.FindWithTag("MinotaurSS"), 10);

}

} 
