using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yaprakTuzak : MonoBehaviour
{
    public GameObject Karakter;
    public GameObject Kamera;
    public GameObject SpotLight;
    public Light Gunes;
    private bool dusmeyeBasla;
    public GameObject taban;
    public float dusmeSuresi;
    private void Update()
    {
        if(dusmeyeBasla ==true)
        {
            float posX = Karakter.transform.position.x;
            Karakter.transform.position = Vector3.MoveTowards(Karakter.transform.position, new Vector3(posX, -50f, Karakter.transform.position.z), dusmeSuresi * Time.deltaTime);

            Karakter.transform.Rotate(0, 0, 100 * Time.deltaTime);
            if (Karakter.transform.position.y <= -37.7f && GameCore.instance.charDead == false)
            {

                GameCore.instance.Dead();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Gunes.enabled = false;
            GameCore.instance.ZıplamaButon.SetActive(false);
            Karakter.GetComponent<CharacterControl>().enabled = false;
            Karakter.GetComponent<Rigidbody2D>().gravityScale = 0;
            Karakter.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            taban.GetComponent<BoxCollider2D>().isTrigger = true;
            Kamera.GetComponent<CameraScript>().enabled = false;
            Kamera.transform.position = new Vector3(Karakter.transform.position.x, -34f, Kamera.transform.position.z);
            SpotLight.transform.position= new Vector3(Kamera.transform.position.x, Kamera.transform.position.y+25f, SpotLight.transform.position.z);

            dusmeyeBasla = true;
        }
    }

}
