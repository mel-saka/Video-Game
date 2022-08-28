using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeusProjectile : MonoBehaviour
{
    private float speed = 3;

    private Transform player;
    private Vector2 target;
 

    public Transform zeusAttackPoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

        
    }
   
    void Update()
    {


        Destroy(gameObject, 3);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

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
            other.GetComponent<Player>().TakeDamage(20);
            DestroyProjectile();
        }
        if (other.gameObject.tag == "Walls")
        {
            DestroyProjectile();
        }
    }



    public void DestroyProjectile()
    {

        GameObject.Destroy(gameObject);
    }
}
