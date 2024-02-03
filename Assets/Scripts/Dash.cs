using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    Rigidbody2D rb;

    public Movement script_movement;
    public Jumping script_jumping;

    public float dashspeed;
    public float dashcd;
    public float dashcdlength;
    public float dashlength;
    public bool dashing;

    private float currentlocation;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dashing = false;
    }
    private void Update()
    {
        dashmethod();
    }

    private void FixedUpdate()
    {
        
    }

    private void dashmethod()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashcd == 0f)
        {
            dashcd = dashcdlength;
            currentlocation = rb.position.x;
            dashing = true;
            script_movement.moving = true;

            if (script_movement.headingright == true)
            {
                rb.velocity = new Vector2(+dashspeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-dashspeed, rb.velocity.y);
            }
        }

        if (rb.position.x >= currentlocation + dashlength && dashing == true)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            dashing = false;
        }
        else if (rb.position.x <= currentlocation + -dashlength && dashing == true)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            dashing = false;
        }

        if(dashcd != 0f)
        {
            dashcd -= Time.deltaTime;

            if(dashcd <= 0f)
            {
                dashcd = 0f;
            }
        }
    }
}
