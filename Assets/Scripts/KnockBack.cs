using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    Rigidbody2D rb;

    public FrictionJoint2D friction;

    public Movement script_movement;

    public float knockbackduration;
    public float knockbackdurationlength;
    public float knockbackrange;
    public bool knockbacking;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        knockbacking = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && knockbackduration == 0f)
        {
            if(script_movement.headingright == true)
            {
                knockbackduration = knockbackdurationlength;
                knockbacking = true;
                rb.velocity = new Vector2(-knockbackrange, rb.velocity.y);
            }
            else
            {
                knockbackduration = knockbackdurationlength;
                knockbacking = true;
                rb.velocity = new Vector2(+knockbackrange, rb.velocity.y);
            }
        }

        if (knockbackduration != 0f)
        {
            knockbackduration -= Time.deltaTime;

            if(knockbackduration <= 0)
            {
                knockbackduration = 0;
                knockbacking = false;
            }
        }
    }

    private void knocked()
    {

    }
}
