using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{

    public float speed = 5f;
    private Vector3 pos;
    private Animator animCam;

    public float YMaxValue;
    public float YMinValue;
    public float XMinValue;
    public float XMaxValue;
    public Transform karakter;

    private Vector3 velocity = Vector3.zero;

    float distance;
    float timer = 0;
    float maxTimer=3.1f;

    public Text sayac;

    public static CameraScript instance;
    [HideInInspector] public bool kameraKontrolEdebilir;
    [HideInInspector] public bool yerKameraKontrol;

    private void Start()
    {
        instance = this;
        sayac = GameObject.Find("Canvas").transform.Find("Sayac").GetComponent<Text>();
        timer = maxTimer;
        animCam = GetComponent<Animator>();
        kameraKontrolEdebilir = true;
        yerKameraKontrol = true;
    }
    void LateUpdate()
    {
        if (GameCore.instance.gameType == 1)
        {
            animCam.SetInteger("GameType", 1);
            pos = transform.position;
            pos.x = Mathf.Clamp(pos.x + speed * Time.deltaTime, XMinValue, XMaxValue);

            if (pos.y > YMinValue - 3.21f) // Karakter yere düşerken
            {
                pos.y = Mathf.Clamp(GameObject.FindGameObjectWithTag("Player").transform.position.y,YMinValue-3.21f,YMaxValue+ 3.21f);
                pos.x = GameObject.FindGameObjectWithTag("Player").transform.position.x + 5f;

            }
            else // Karakter yerde hareket ederken
            {
                if(karakter.gameObject.GetComponent<CharacterControl>().IsGrounded() && yerKameraKontrol == true)
                {
                    kameraKontrolEdebilir = true;
                    pos.x = GameObject.FindGameObjectWithTag("Player").transform.position.x + 5f;
                    yerKameraKontrol = false;
                }
               pos.y = YMinValue - 3.21f;
            }
            pos.z = -10;
            transform.position = pos;
        }
        else if(GameCore.instance.gameType == 0)
        {
            animCam.SetInteger("GameType", 0);
            ipCamera();
        }
        KarakterKameraKontrol();

    }


    private void ipCamera()
    {

        pos = transform.position;

        if (transform.position.x-10 <= GameObject.FindGameObjectWithTag("Player").transform.position.x && animCam.GetBool("DoSlow") == false)
        {
            pos.x = karakter.position.x+10f;
            //transform.position = Vector3.Lerp(transform.position, pos, 42f * Time.deltaTime);
            //pos.x = Vector3.Lerp(pos.x, pos.x + (speed * 2), 0.25f * Time.deltaTime);
        }
        
        pos.x += speed * Time.deltaTime;
        pos.y = -5;
        //pos.y = Mathf.Clamp(GameObject.FindGameObjectWithTag("Player").transform.position.y, YMinValue, YMaxValue);
        //pos.y = GameObject.FindGameObjectWithTag("Player").transform.position.y;

        pos.z = -10;

        transform.position = pos;
        
       
    }

    private void KarakterKameraKontrol()
    {
        if (kameraKontrolEdebilir)
        {

            Vector3 screenPoint = gameObject.GetComponent<Camera>().WorldToViewportPoint(GameCore.instance.Player.transform.position);
            bool onScreen = screenPoint.z > 0 && screenPoint.x > -0.05f && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

            if (!onScreen && GameCore.instance.charDead == false)
            {
                sayac.enabled = true;
                //Camera.main.ScreenToWorldPoint(sayac.transform.position);
                sayac.text = "" + timer.ToString("F1");
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    sayac.enabled = false;
                    Debug.Log("kamera");
                    GameCore.instance.Dead();
                }
            }
            else
            {
                sayac.enabled = false;
                timer = maxTimer;
            }
        }



       /* if ( distance < dis && GameCore.instance.charDead == false)
        {
            sayac.enabled = true;
           //Camera.main.ScreenToWorldPoint(sayac.transform.position);
            sayac.text = ""+ timer.ToString("F1");
            timer -= Time.deltaTime;
            if(timer<=0)
            {
                sayac.enabled = false;
                GameCore.instance.Dead();
            }
        }
        else
        {
            sayac.enabled = false;
            timer = maxTimer;
        }*/
    }
}
