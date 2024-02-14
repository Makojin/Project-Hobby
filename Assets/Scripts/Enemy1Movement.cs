using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    Rigidbody2D rb;

    public float patrolspeed;
    public float patrolrange;
    public float randomizertimer;

    public bool lookingright;
    public bool lookswitch;

    public float startingpoint;
    public float randomizertimerholder;
    public float randomizer;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startingpoint = rb.position.x;
        randomizertimerholder = randomizertimer;

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
        randomizertimerholder -= Time.deltaTime;

        if(randomizertimerholder < 0)
        {
            Debug.Log("behaviour change");
            randomizer = Random.Range(0,3);

            randomizertimerholder = randomizertimer;

            lookswitch = true;
        }

        if(randomizer == 0)
        {
            rb.velocity = new Vector2(0f,0f);
        }
        else if(randomizer == 1)
        {
            if(lookingright == true && lookswitch == true)
            {
                lookingright = false;

                lookswitch = false;
            }
            else if(lookingright == false && lookswitch == true)
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

    private void move()
    {
        if (lookingright == true)
        {
            rb.velocity = new Vector2(patrolspeed, 0f);

            if (startingpoint + patrolrange <= rb.position.x)
            {
                lookingright = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-patrolspeed, 0f);

            if (startingpoint + -patrolrange >= rb.position.x)
            {
                lookingright = true;
            }
        }
    }

    private void turnaround()
    {

    }
}
