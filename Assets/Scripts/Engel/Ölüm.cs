using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ölüm : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            GameCore.instance.Dead();
        }
    }
}
