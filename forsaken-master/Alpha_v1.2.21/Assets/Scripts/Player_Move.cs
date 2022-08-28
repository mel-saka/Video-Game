using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public Animator animator;

    private float attackTime = 0.5f;
    private float attackCounter = 0.5f;
    private bool isAttacking;
    Vector2 movement;

    //public Transform attackPoint;
    //public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    /*Dash variables*/
    public float dashSpeed;
    private float dashTime;

    public float startDashTime;

    private int direction;

    public GameObject dashEffect;

    public int attackDamage = 40;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 8f;
        }
        else
        {
            moveSpeed = 5f;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        /*animator.SetFloat("Walk", moveSpeed);*/
        /*animator.SetFloat("Walk", movement.y);*/

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastHorizontal", Input.GetAxisRaw("Horizontal"));
            /*animator.SetFloat("lastVertical", Input.GetAxisRaw("Vertical"));*/
        }

        if (isAttacking)
        {
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                //animator.SetBool("isAttacking", false);
                //isAttacking = false;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            attackCounter = attackTime;
            //animator.SetBool("isAttacking", true);
            //isAttacking = true;
            //Attack();
        }
        if (direction == 0)
        {

            if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetKeyDown(KeyCode.Space))
            {
                SoundManagerScript.PlaySound("dash");
                direction = 1;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                
            }
            if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetKeyDown(KeyCode.Space)) 
            {
                SoundManagerScript.PlaySound("dash");
                direction = 2;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
 
            }
            if (Input.GetAxisRaw("Vertical") == 1 && Input.GetKeyDown(KeyCode.Space)) 
            {
                SoundManagerScript.PlaySound("dash");
                direction = 3;
                Instantiate(dashEffect, transform.position, Quaternion.identity);

            }
            if (Input.GetAxisRaw("Vertical") == -1 && Input.GetKeyDown(KeyCode.Space))
            {
                SoundManagerScript.PlaySound("dash");
                direction = 4;
                Instantiate(dashEffect, transform.position, Quaternion.identity);

            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;

            }
            else
            {
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    rb.AddForce(Vector2.right * dashSpeed);
                }
                else if (direction == 2)
                {
                    rb.AddForce(Vector2.left * dashSpeed);
                }
                else if (direction == 3)
                {
                    rb.AddForce(Vector2.up * dashSpeed) ;
                }
                else if (direction == 4)
                {
                    rb.AddForce(Vector2.down * dashSpeed);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    //void Attack()
    //{
    //    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
    //    foreach (Collider2D enemy in hitEnemies)
    //    {
    //        Debug.Log("We hit" + enemy.name);
    //        enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
    //    }
    //}

}
