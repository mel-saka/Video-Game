using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashMove : MonoBehaviour
{

    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;

    public float startDashTime;

    private int direction;

    public GameObject dashEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                
                direction = 1;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                
                direction = 2;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                
                direction = 3;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                
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
                if(direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }else if (direction == 3)
                {
                    rb.velocity = Vector2.up * dashSpeed;
                }else if(direction == 4)
                {
                    rb.velocity = Vector2.down * dashSpeed;
                }
            }
        }

    }
}
