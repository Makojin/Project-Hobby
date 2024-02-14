using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackPlayer : MonoBehaviour
{
    public Rigidbody2D rb;

    public Movement script_movement;
    public Jumping script_jumping;
    public Dash script_dash;

    public float knockbackduration;
    public float knockbackdurationlength;
    public float knockbackrange;

    void Start()
    {
        script_movement.knockbacking = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && knockbackduration == 0f)
        {
            knocked();
        }

        if (knockbackduration != 0f)
        {
            knockbackduration -= Time.deltaTime;

            if (knockbackduration <= 0)
            {
                script_dash.dashing = false;
                script_dash.dashingallowed = true;
                script_jumping.jumpingallowed = true;

                knockbackduration = 0;

                script_movement.knockbacking = false;
            }
        }
    }

    public void knocked()
    {
        script_movement.knockbacking = false;

        if(this.transform.position.x >= rb.transform.position.x)
        {
            script_dash.dashingallowed = false;
            script_jumping.jumpingallowed = false;

            knockbackduration = knockbackdurationlength;

            script_movement.knockbacking = true;

            rb.velocity = new Vector2(-knockbackrange, knockbackrange / 2);
        }
        else
        {
            script_dash.dashingallowed = false;
            script_jumping.jumpingallowed = false;

            knockbackduration = knockbackdurationlength;

            script_movement.knockbacking = true;

            rb.velocity = new Vector2(+knockbackrange, knockbackrange / 2);
        }
    }
}
    

