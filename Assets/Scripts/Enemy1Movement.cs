using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    Rigidbody2D rb;

    public CircleCollider2D aggro;
    public CircleCollider2D aggroexit;

    public GameObject foot;
    public GameObject playerhitcollision;

    public float patrolspeed;
    public float patrolrange;
    public float randomizertimer;

    public bool lookingright;
    public bool lookswitch;

    public float startingpoint;
    public float randomizertimerholder;
    public float randomizer;

    public bool aggroed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startingpoint = rb.position.x;

        randomizertimerholder = randomizertimer;

        aggroed = false;

        aggroexit.enabled = false;

        if (Random.Range(0, 2) == 0)
        {
            lookingright = true;
        }
        else
        {
            lookingright = false;
        }
    }

    private void Update()
    {
        if (aggroed == true)
        {

            if (playerhitcollision.transform.position.x <= this.transform.position.x)
            {
                rb.velocity = new Vector2(-patrolspeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(patrolspeed, rb.velocity.y);
            }
        }
        else
        {
            randomizertimerholder -= Time.deltaTime;

            if (randomizertimerholder < 0)
            {
                randomizer = Random.Range(0, 3);

                randomizertimerholder = randomizertimer;

                lookswitch = true;
            }

            if (randomizer == 0)
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }
            else if (randomizer == 1)
            {
                if (lookingright == true && lookswitch == true)
                {
                    lookingright = false;

                    lookswitch = false;
                }
                else if (lookingright == false && lookswitch == true)
                {
                    lookingright = true;

                    lookswitch = false;
                }
                move();
            }
            else if (randomizer == 2)
            {
                move();
            }
        }
    }

    private void move()
    {
        if (lookingright == true)
        {
            rb.velocity = new Vector2(patrolspeed, rb.velocity.y);

            if (startingpoint + patrolrange <= rb.position.x)
            {
                lookingright = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-patrolspeed, rb.velocity.y);

            if (startingpoint + -patrolrange >= rb.position.x)
            {
                lookingright = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && foot.transform.position.y < playerhitcollision.transform.position.y)
        {
            aggroed = true;

            aggro.enabled = false;
            aggroexit.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            aggroed = false;

            aggro.enabled = true;
            aggroexit.enabled = false;
        }
    }
}
