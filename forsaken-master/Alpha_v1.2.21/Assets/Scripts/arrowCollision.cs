using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowCollision : MonoBehaviour
{
    public static int arrowDamage = 15;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag  == "Boss")
        {
            other.GetComponent<ZuesAi>().TakeDamage(arrowDamage);
            DestroyProjectile();
        }

        if (other.gameObject.tag == ("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(arrowDamage);
            DestroyProjectile();
            /*other.GetComponent<MedusaAi>().TakeDamage(20);*/
        }
        else if(other.gameObject.tag == ("Medusa"))
        {


            other.GetComponent<MedusaAi>().TakeDamage(arrowDamage);
            DestroyProjectile();
            /*other.GetComponent<MedusaAi>().TakeDamage(20);*/
        }
        else if(other.gameObject.tag == "Walls")
        {
            DestroyProjectile();
        }
    }
    public void DestroyProjectile()
    {

        GameObject.Destroy(gameObject);
    }
}
