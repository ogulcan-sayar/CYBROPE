using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaslangicKontrol : MonoBehaviour
{
    public AudioSource audioFx;
    public GameObject baslangicKontrol;
    public Button but;

    private void Start()
    {
        if(GameCore.tekrardanOynaniliyor==false)
        {
            audioFx.volume = 0f;
            Time.timeScale = 0f;
            baslangicKontrol.SetActive(true);
        }

    }


    public void Anladim()
    {

        audioFx.volume = 1f;
        baslangicKontrol.SetActive(false);

        Time.timeScale = 1f;

    }

}
