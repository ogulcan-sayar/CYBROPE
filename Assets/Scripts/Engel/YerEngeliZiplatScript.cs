using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YerEngeliZiplatScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterControl>().set_engeleCarpti = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterControl>().set_engeleCarpti = false;
        }
    }

}
