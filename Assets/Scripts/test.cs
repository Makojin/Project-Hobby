using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit3d");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
    }
}
