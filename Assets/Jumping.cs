using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] int Jumppower;

    public Transform GroundCheck;
    public LayerMask GroundLayer;
    bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        checker();

        isGrounded = Physics2D.OverlapCapsule(GroundCheck.position,new Vector2(1f,0.1f),CapsuleDirection2D.Horizontal, 0, GroundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, Jumppower);
        }
    }

    private void FixedUpdate()
    {
        
    }
    private void checker()
    {
        if (Input.GetKey(KeyCode.X))
        {
            Debug.Log(isGrounded.ToString());
        }
    }
}
