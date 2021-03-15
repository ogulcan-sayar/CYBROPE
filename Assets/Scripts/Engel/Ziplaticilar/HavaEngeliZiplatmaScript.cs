using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavaEngeliZiplatmaScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<CharMaterialControl>().startYanmaEffect == false)
        {
            if (GameCore.instance.charDead == false)
            {
                collision.gameObject.GetComponent<CharacterControl>().kol.SetActive(false);

                collision.gameObject.GetComponent<Animator>().SetTrigger("EngeldenZipla");

                //collision.gameObject.GetComponent<CharacterControl>().ipiBirak();
                StartCoroutine(StartSwipe());

                SoundManager.playsound("ziplama");
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, 26.23f);
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(16.2f, collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
                // collision.gameObject.GetComponent<Animator>().SetTrigger("Degistir");
            }
        }
    }
    /*private void OnTriggerEnter2D(Collision2D collision)
    {
       
    }*/

    protected virtual IEnumerator StartSwipe()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SwipeScript>().Hold = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SwipeScript>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<SwipeScript>().enabled = true;
        yield return new WaitForSeconds(0.3f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>().kol.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("Degistir");
    }
}
