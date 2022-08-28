using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer, playerLayer;

    public float attackRange = 0.5f;
    public static int attackDamage = 20;

    public float attackRate = 2f;
    public float nextAttackTime = 0.2f;

    public float timerAttack;

    /*Sword animation*/
    public Sprite[] spriteArray;
    public Sprite[] spriteAttack;
    public float animSpeed = 0.065f;

  //  float speed = 10;

//    float timer = 0;
    public static bool attacking;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timerAttack += Time.deltaTime;
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                nextAttackTime = Time.time + 1f / attackRate;
                
                Attack();
                newAttack();
                /*if (timer > 8 * animSpeed)
                {

                    timer = 0;
                }
                timer += Time.deltaTime;
                {
                    if (timer < 1 * animSpeed)
                    {
                        GetComponent<SpriteRenderer>().sprite = spriteAttack[0];
                    }
                    if (timer > 1 * animSpeed && timer < 2 * animSpeed)
                    {
                        GetComponent<SpriteRenderer>().sprite = spriteAttack[1];
                    }
                    if (timer > 2 * animSpeed && timer < 3 * animSpeed)
                    {
                        GetComponent<SpriteRenderer>().sprite = spriteAttack[2];
                    }
                    if (timer > 3 * animSpeed && timer < 4 * animSpeed)
                    {
                        GetComponent<SpriteRenderer>().sprite = spriteAttack[3];
                    }
                    if (timer > 4 * animSpeed && timer < 5 * animSpeed)
                    {
                        GetComponent<SpriteRenderer>().sprite = spriteAttack[4];
                    }
                    if (timer > 5 * animSpeed && timer < 6 * animSpeed)
                    {
                        GetComponent<SpriteRenderer>().sprite = spriteAttack[5];
                    }
                    if (timer > 6 * animSpeed && timer < 7 * animSpeed)
                    {
                        GetComponent<SpriteRenderer>().sprite = spriteAttack[6];
                    }
                    if (timer > 7 * animSpeed && timer < 8 * animSpeed)
                    {
                        GetComponent<SpriteRenderer>().sprite = spriteAttack[7];

                    }
                }
                if (Time.timeScale == 0)
                {

                    GetComponent<SpriteRenderer>().sprite = spriteArray[0];
                }*/
            }
        }
    }

    void Attack()
    {
        SoundManagerScript.PlaySound("sword");
        animator.SetTrigger("Attack");
    }
    void newAttack()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<ZuesAi>())
            {
                enemy.GetComponent<ZuesAi>().TakeDamage(attackDamage);
            }
            else if (enemy.GetComponent<Enemy>())
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                

            }
            else if (enemy.GetComponent<MedusaAi>())
            {
                enemy.GetComponent<MedusaAi>().TakeDamage(attackDamage);
            }
            timerAttack = Time.time + 1f / 100;
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
