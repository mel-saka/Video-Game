using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    private Animator animator;
    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float range;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    private int attackDamage = 15;

    public float attackRate = 2f;
    float nextAttackTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = FindObjectOfType<Player_Move>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        if (target != null)
        {
            if (Vector3.Distance(target.position, transform.position) <= range)
            {
                if (Time.time >= nextAttackTime)
                {
                    //animator.SetBool("isAttacking", true);
                    Attack();
                    nextAttackTime = Time.time + 2f / attackRate;
                }
            }
            //if (Vector3.Distance(target.position, transform.position) > range)
            //{
            //    animator.SetBool("isAttacking", false);
            //}
        }
        //if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        //{
        //    animator.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
        //    animator.SetFloat("moveY", Input.GetAxisRaw("Vertical"));
        //}
    }

    public void FollowPlayer()
    {
        //    animator.SetBool("isMoving", true);
        if (target != null)
        {
            animator.SetFloat("moveX", (target.position.x - transform.position.x));
            animator.SetFloat("moveY", (target.position.y - transform.position.y));
            //        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D player in hitPlayer)
        {
            Debug.Log("We hit" + player.name);
            player.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
