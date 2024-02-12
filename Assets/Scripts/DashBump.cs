using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBump : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sp;

    public Movement script_movement;
    public Dash script_dash;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);

            script_dash.dashing = false;

            sp.color = new Color(255, 0, 0, 255);

            Debug.Log("hit");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            sp.color = new Color(0, 255, 0, 255);
        }
    }

}
