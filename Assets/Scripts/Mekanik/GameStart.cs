using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public ParticleSystem explosionFX;
    //public GameObject redLight;
    public float timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*timer += Time.deltaTime*4f;
        if((int)timer % 2 == 0 && timer<20)
        {
            redLight.SetActive(true);
        }
        else if(timer<20)
        {
            redLight.SetActive(false);
        }*/

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.playsound("girisPatlama");
            explosionFX.gameObject.SetActive(true);
            Destroy(explosionFX, 3f);
            CameraShaking.instance.StartShake(.5f, .5f);
            //redLight.SetActive(false);
        }
        

        
    }
}
