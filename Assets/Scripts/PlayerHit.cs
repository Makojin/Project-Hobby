using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public KnockBackPlayer script_knockback;

    private bool insidedanger;

    private void Start()
    {
    }

    private void Update()
    {
        if(insidedanger == true)
        {
            script_knockback.knocked();
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
