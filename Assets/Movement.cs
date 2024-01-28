using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 move;

    [SerializeField] float Dash;
    [SerializeField] float Speed;
    bool isGrounded;

    private bool headingright;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        headingright = true;
    }

    private void Update()
    {
        Debug.Log(rb.velocity);

        checker();

        if (Input.GetKey(KeyCode.A))
        {
            headingright = false;
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            headingright = true;
            rb.velocity = new Vector2(+Speed, rb.velocity.y);
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            if(headingright == true)
            {
                rb.velocity = new Vector2(+Speed * Dash, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-Speed * Dash, rb.velocity.y);
            }
        }
    }
}
