using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRocket : MonoBehaviour
{

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * 10f * Time.deltaTime, Space.World);
        if(RocketScript.timer >= 10)
        {
            RocketScript.ResetRocket();
            RocketScript.instance.poolRocket.HavuzaObjeEkle(gameObject);
           // Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PerkKalkan"))
        {
            RocketScript.instance.poolRocket.HavuzaObjeEkle(gameObject);
            //Destroy(gameObject);
            RocketScript.ResetRocket();
        }
        else if (collision.CompareTag("Player"))
        {
            
            if (GameCore.instance.PerkKoruma == false)
            {
                Debug.Log("movingrocket");
                GameCore.instance.Dead();
                RocketScript.instance.poolRocket.HavuzaObjeEkle(gameObject);
                //Destroy(gameObject);
                RocketScript.ResetRocket();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PerkKalkan"))
        {
            if (GameCore.instance.PerkKoruma == true)
            {
                GameCore.instance.ResetAirPerks();
            }
        }
    }
}
