using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public Transform firepoint;
    public GameObject arrowprefab;
    
    public float fireRate = 1.0f;
    private float elapsedTime = 0;

    public float arrowforce = 20f;

    public LayerMask enemyLayer;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > elapsedTime)
        {
            shoot();
            elapsedTime = Time.time + fireRate;
        }
    }

    void shoot()
    {
        SoundManagerScript.PlaySound("bow");
        GameObject arrow = Instantiate(arrowprefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * arrowforce, ForceMode2D.Impulse);
        
    }

}
