using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform GroundCheck;
    public LayerMask GroundLayer;

    public float jumppower;
    public bool grounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCapsule(GroundCheck.position,new Vector2(1f,0.1f),CapsuleDirection2D.Horizontal, 0, GroundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumppower);
        }
    }

    private void FixedUpdate()
    {
        
    }
}
