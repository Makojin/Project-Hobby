using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    public Jumping script_jumping;

    public float speed;
    public bool headingright;
    public bool moving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        headingright = true;
        moving = false;
    }

    private void Update()
    {
        Debug.Log(rb.velocity);

        checker();

        if (Input.GetKey(KeyCode.A))
        {
            moving = true;
            headingright = false;
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moving = true;
            headingright = true;
            rb.velocity = new Vector2(+speed, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            moving = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moving = false;
        }

        if(moving == false && script_jumping.grounded == true)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    private void FixedUpdate()
    {

    }

    private void checker()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log(rb.velocity.y.ToString());
        }
    }
}
