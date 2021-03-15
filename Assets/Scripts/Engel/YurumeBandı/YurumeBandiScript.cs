using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YurumeBandiScript : MonoBehaviour
{
    public GameObject Engel;
    public Transform baslangicNoktasi;
    private float timer;
    public float dogmaSuresi;
    public int engelSayisi;
    private int engelSayisiCounter;
    private bool canCreate;
    public bool set_canCreate { set { canCreate = value; } }


    // Update is called once per frame
    void Update()
    {
        
        if(canCreate == true)
        {
            timer += Time.deltaTime;
            //dogmaSuresi = Random.Range(DogmaSuresiAraligi[0], DogmaSuresiAraligi[1]);
            if(timer >= dogmaSuresi && engelSayisiCounter<=engelSayisi)
            {
                Instantiate(Engel, baslangicNoktasi.position, Quaternion.identity,gameObject.transform);
                timer = 0;
                engelSayisiCounter++;
            }
        }
    }

    public void EngelYarat()
    {
        Instantiate(Engel, baslangicNoktasi.position, Quaternion.identity, gameObject.transform);
    }

}
