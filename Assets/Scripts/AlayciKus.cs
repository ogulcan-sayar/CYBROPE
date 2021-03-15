using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AlayciKus : MonoBehaviour
{
    public GameObject yumurta;
    public GameObject coconut;
    public GameObject dogumYeri;
    public GameObject Cam;
    private Vector3 screenPoint;
    private bool onScreen;
    private bool solda;
    private bool olustur;
    public float timer;
    private bool yumurtaolustur;
    // Update is called once per frame
    void Update()
    {
        if(KusBasla.basla==true)
        { 
            
            screenPoint = Camera.main.WorldToViewportPoint(gameObject.transform.position);
            if (screenPoint.x <= 0.1 )
            {
                solda = true;
                olustur = false;
            }
            else if(screenPoint.x >=1.290)
            {
                solda = false;
                olustur = false;
            }
            else if (screenPoint.x > 0.9)
            {
                yumurtaolustur = false;
            }

            if(solda == false)
            {
               
                gameObject.GetComponent<SpriteRenderer>().flipX = false;

                //coconut dogus
                if (screenPoint.x > 1.2 && screenPoint.x < 1.21 && olustur == false)
                {
                    coconut= Instantiate(coconut, dogumYeri.gameObject.transform.position, Quaternion.identity);
                    coconut.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1.5f,-2f),ForceMode2D.Impulse);
                    olustur = true;
                }

                transform.Translate(Vector2.left * 1.5f * Time.deltaTime, Space.World);


                //yumurta dogus
                if (screenPoint.x >0.993 && screenPoint.x < 1.0 && yumurtaolustur ==false)
                    {

                      yumurta=Instantiate(yumurta, dogumYeri.gameObject.transform.position, Quaternion.identity);
                      yumurta.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 0f), ForceMode2D.Impulse);
                      yumurtaolustur =true;
                    }


            }
            else 
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;

                //coconut dogus
                if (screenPoint.x > 0.1 && screenPoint.x < 0.113 && olustur == false)
                {

                    coconut=Instantiate(coconut, dogumYeri.gameObject.transform.position, Quaternion.identity);
                    coconut.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f, -2f),ForceMode2D.Impulse);
                    olustur = true;
                }

                transform.Translate(Vector2.right * 10f * Time.deltaTime, Space.World);



            }
  

        }

    }
    



}
