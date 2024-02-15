using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    TrailRenderer trails;

    Rigidbody2D rb;

    public Movement script_movement;
    public Jumping script_jumping;

    public float trailsdurationtimer;
    public float trailsduration;

    public bool trailsenabled;

    public float dashcd;
    public float dashspeed;
    public float dashcdlength;
    public float dashlength;

    public bool dashing;
    public bool dashingallowed;

    private float currentlocation;

    private void Start()
    {
        trails = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody2D>();

        dashing = false;
        dashingallowed = true;
    }
    private void Update()
    {
        dashmethod();

        if (trailsenabled == true)
        {
            trailings();
        }
    }

    private void dashmethod()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashcd == 0f && dashingallowed == true)
        {
            trailsdurationtimer = trailsduration;

            trailsenabled = true;

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

    private void trailings()
    {
        if(trailsdurationtimer >= 0)
        {
            trails.startColor = new Color(255, 0, 0, 255);
            trailsdurationtimer -= Time.deltaTime;

            if(trailsdurationtimer <= 0)
            {
                trails.startColor = new Color(0, 255, 0, 255);
                trailsdurationtimer = 0;
                trailsenabled = false;
            }
        }
    }
}
