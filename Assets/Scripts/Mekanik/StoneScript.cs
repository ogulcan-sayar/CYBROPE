using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    public GameObject tavan;
    void Start()
    {

        tavan = GameObject.Find("tavan");
        Physics2D.IgnoreCollision(gameObject.GetComponent<EdgeCollider2D>(), tavan.GetComponent<BoxCollider2D>());
        CameraShaking.instance.StartShake(.5f, .5f);
        
    }


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.name == "taban")
       {
         //  Physics2D.IgnoreCollision(gameObject.GetComponent<EdgeCollider2D>(), tavan.GetComponent<BoxCollider2D>(), false);
           StoneRainScript.instance.stoneRainPool.HavuzaObjeEkle(gameObject);
       }

    }

  
}
