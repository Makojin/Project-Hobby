using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackPlayer : MonoBehaviour
{
    public Rigidbody2D playerrb;

    public Movement script_movement;
    public Jumping script_jumping;
    public Dash script_dash;

    public float knockbackrange;
    public float knockbackdurationlength;
    public float knockbackduration;

    void Start()
    {
        script_movement.knockbacking = false;
    }

    void Update()
    {
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

        if(this.transform.position.x >= playerrb.transform.position.x)
        {
            script_dash.dashingallowed = false;
            script_jumping.jumpingallowed = false;
            script_movement.knockbacking = true;

            knockbackduration = knockbackdurationlength;

            playerrb.velocity = new Vector2(-knockbackrange, knockbackrange / 2);
        }
        else
        {
            script_dash.dashingallowed = false;
            script_jumping.jumpingallowed = false;
            script_movement.knockbacking = true;

            knockbackduration = knockbackdurationlength;

            playerrb.velocity = new Vector2(+knockbackrange, knockbackrange / 2);
        }
    }
}
    

