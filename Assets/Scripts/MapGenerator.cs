    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MapGenerator : MonoBehaviour
{
    public static MapGenerator instance;
    public GameObject[] HavaOyunuTaslaklari;
    public GameObject[] DigerOyunTaslaklari;
    public GameObject geciciTaslak;
    public GameObject Zemin;
    public GameObject yapayZekaCollider;
    public GameObject yerEngeli;

    public int modDegiskeni;
   
    [HideInInspector] public int gameTypeCounter;
    
    private void Awake()
    {
        instance = this;
        gameTypeCounter = 1;
        
    }



    public void YapayZekayiCalistir()
    {
        HaritaSil();
        gameTypeCounter++;
        if (gameTypeCounter % modDegiskeni == 0)
        {
            HaritaSec(1);
            
        }
        else
        {
            HaritaSec(0);
        }
    }

    public void HaritaSec(int gameType)
    {
        if(gameType == 0)
        {
            int temp;
            temp = Random.Range(0, HavaOyunuTaslaklari.Length);
            Debug.Log(Zemin.GetComponent<SpriteRenderer>().bounds.size.x);
            Vector3 pos =new Vector3(yapayZekaCollider.transform.position.x + Zemin.GetComponent<Parallax>().length + (Zemin.GetComponent<SpriteRenderer>().bounds.size.x),
                yapayZekaCollider.transform.position.y,
                yapayZekaCollider.transform.position.z
                );
            geciciTaslak= Instantiate(HavaOyunuTaslaklari[temp], pos, Quaternion.identity,gameObject.transform);
            ColliderAcKapat();
        }
        else if(gameType == 1)
        {
            int temp;
            temp = Random.Range(0, DigerOyunTaslaklari.Length);
            Vector3 pos = new Vector3(yapayZekaCollider.transform.position.x + Zemin.GetComponent<Parallax>().length + (Zemin.GetComponent<SpriteRenderer>().bounds.size.x),
                yapayZekaCollider.transform.position.y,
                yapayZekaCollider.transform.position.z
                );
            geciciTaslak = Instantiate(DigerOyunTaslaklari[temp], pos, Quaternion.identity, gameObject.transform);
            //ColliderAcKapat();
        }
        
    }

    void HaritaSil()
    {
        if (gameObject.transform.childCount >= 4)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
        }
    }

    void ColliderAcKapat()
    {
        if(gameTypeCounter == modDegiskeni - 1)
        {
            geciciTaslak.transform.Find("GameType").gameObject.SetActive(true);
        }
        else
        {
            geciciTaslak.transform.Find("GameType").gameObject.SetActive(false);
        }
    }
}
