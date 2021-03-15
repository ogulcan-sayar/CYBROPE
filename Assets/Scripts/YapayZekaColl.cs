using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YapayZekaColl : MonoBehaviour
{
    public SpriteRenderer[] Zeminler;
    public Sprite YerZemini;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision is BoxCollider2D)
        {

            StartCoroutine(YapayZeka());
            
        }
    }

    IEnumerator YapayZeka()
    {
        Debug.Log("yapaycol");
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        MapGenerator.instance.YapayZekayiCalistir();
        GecisZeminiHazirla();
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    void GecisZeminiHazirla()
    {
        StartCoroutine(GecisZeminiHazirlaEnum());
    }

    public void YerZeminleriniHazirla()
    {
        for(int index = 0; index < Zeminler.Length; index++)
        {
            Zeminler[index].sprite = YerZemini;
        }
    }

    IEnumerator GecisZeminiHazirlaEnum()
    {
        if (MapGenerator.instance.gameTypeCounter % MapGenerator.instance.modDegiskeni == 0 && GameCore.instance.gameType == 0)
        {
            Zeminler[Zeminler.Length - 1].sprite = YerZemini;
            yield return new WaitForSeconds(5f);
            Zeminler[0].sprite = YerZemini;
        }
        else if (GameCore.instance.gameType == 1)
        {
            Debug.Log(MapGenerator.instance.gameTypeCounter);
        }
    }
}
