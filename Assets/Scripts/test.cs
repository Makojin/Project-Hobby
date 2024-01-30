using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Rigidbody2D rb;

    public Movement script_movement;
    public Dash script_dash;

    private void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
        script_dash.dashing = false;
    }
}
