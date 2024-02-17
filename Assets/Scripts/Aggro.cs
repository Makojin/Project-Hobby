using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggro : MonoBehaviour
{
    public Enemy1Movement e1m_script;

    public GameObject foot;

    public CircleCollider2D aggro;
    public CircleCollider2D aggroexit;

    private void Start()
    {
        aggroexit.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && foot.transform.position.y < e1m_script.playerhitcollision.transform.position.y)
        {
            e1m_script.aggroed = true;

            aggro.enabled = false;
            aggroexit.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            e1m_script.aggroed = false;

            aggro.enabled = true;
            aggroexit.enabled = false;
        }
    }
}
