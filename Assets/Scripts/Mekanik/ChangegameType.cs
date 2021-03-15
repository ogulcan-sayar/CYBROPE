using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangegameType : MonoBehaviour
{

    public int changeGameType;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameCore.instance.gameType = changeGameType;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("Degistir");
            GameObject.Find("Main Camera").GetComponent<Animator>().SetTrigger("Degistir");
            CameraScript.instance.kameraKontrolEdebilir = false;

            switch (GameCore.instance.gameType)
            {
                case 0:
                    
                    GameCore.instance.buttonCoolDown = 0f;
                    GameCore.instance.ZıplamaButon.SetActive(true);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>().kol.SetActive(true);
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>().kol.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    StartCoroutine(StartSwipe());
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 2f;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.up * 25f + Vector2.right * 8f;
                    RocketScript.ResetRocket();
                    
                    break;
                case 1:
                    if (GameCore.instance.levelIndex != 1) // 1. bölümde yer engeli olmadığı için
                    {
                        MapGenerator.instance.yerEngeli.SetActive(false);
                        MapGenerator.instance.yapayZekaCollider.GetComponent<YapayZekaColl>().YerZeminleriniHazirla();
                    }
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>().kol.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    GameCore.instance.ResetAirPerks();
                    GameCore.instance.ZıplamaButon.SetActive(false);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>().kol.SetActive(false);
                    Camera.main.GetComponent<CameraScript>().yerKameraKontrol = true;
                    
                    break;
            }

        }

        

    }

    IEnumerator StartSwipe()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SwipeScript>().Hold = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SwipeScript>().enabled = false;
        yield return new WaitForSeconds(0.7f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<SwipeScript>().enabled = true;
        CameraScript.instance.kameraKontrolEdebilir = true;
        if(GameCore.instance.levelIndex != 1) // 1. bölümde yer engeli olmadığı için
        {
            MapGenerator.instance.yerEngeli.SetActive(true);
        }
        
    }

    

}
