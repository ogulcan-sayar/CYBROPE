using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YurumeBandiBaslat : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.parent.GetComponent<YurumeBandiScript>().set_canCreate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.parent.GetComponent<YurumeBandiScript>().set_canCreate = false;
        }
    }

}
