using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaProjectile : MonoBehaviour
{
    public float speed = 20f;

    private Transform player;
    private Vector2 target;

    public Transform arrowAttackPoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Debug.Log("We have reached our destination");
            DestroyProjectile();

        }
        //if(arrowAttackPoint.position == new Vector3(player.position.x, player.position.y))
        //{
        //    Debug.Log("We collided with player");
        //}
    }
    //Vector3.Distance(target.position, transform.position) <= range)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            other.GetComponent<Player>().TakeDamage(10);
            DestroyProjectile();
        }
        if(other.gameObject.tag == "Walls")
        {
            DestroyProjectile();
        }
    }



    public void DestroyProjectile(){

        GameObject.Destroy(gameObject);
        }
    }



