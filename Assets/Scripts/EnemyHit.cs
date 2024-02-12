using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public KnockBack script_knockback;

    public SpriteRenderer sp;
    public Collider2D c2;

    public Rigidbody2D rbplayer;

    public float colorduration;
    public float colortimer;
    public float colorduration2;
    public float colortimer2;

    private bool hitswitch;
    private bool insidedanger;

    private void Start()
    {
        colortimer = colorduration;
        colortimer2 = colorduration2;
    }

    private void Update()
    {
        colorchange();

        if(insidedanger == true && hitswitch == true)
        {
            script_knockback.knocked();
        }
    }

    private void colorchange()
    {
        if (colortimer != 0)
        {
            sp.color = new Color(0, 255, 0, 100);

            hitswitch = false;

            colortimer -= Time.deltaTime;

            if (colortimer <= 0)
            {
                if (colortimer2 != 0)
                {
                    sp.color = new Color(255, 0, 0, 100);

                    hitswitch = true;

                    colortimer2 -= Time.deltaTime;

                    if (colortimer2 <= 0)
                    {
                        colortimer = colorduration;
                        colortimer2 = colorduration2;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            insidedanger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            insidedanger = false;
        }
    }
}
