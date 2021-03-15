using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KusBasla : MonoBehaviour
{
   
    public static bool basla;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            basla = true;
        }
    }
}
