using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CikisKapisi : MonoBehaviour
{
    // Start is called before the first frame update
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CameraScript.instance.kameraKontrolEdebilir = false;
            gameObject.GetComponent<Animator>().SetBool("KapiyiAc", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().SetBool("KapiyiAc", false);
        }
    }

}
