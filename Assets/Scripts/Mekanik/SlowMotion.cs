using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public Transform karakter;
    public float slowDown = 0.025f;
    public float slowDownLenght = 2f;
    float distance;
    Vector2 dis;
    Vector2 pos;

    public GameObject mainCam;
    // camera
    int zoom = 1;
    int normal = 60;
    int smooth = 5;
    bool zoomActive = false;
    bool carpti;
    bool girdi;
    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = Time.timeScale * .02f;
        pos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 charPos = karakter.position;

        Vector2 dis = charPos - pos;


        if (Mathf.Abs(dis.magnitude) < 0.75f && carpti == false)
        {
      
            doSlowMotion();
            mainCam.GetComponent<Animator>().SetBool("DoSlow", true);
            girdi = true;
            
        }
        else if (Mathf.Abs(dis.magnitude) >= 0.75f && girdi == true)
        {
            mainCam.GetComponent<Animator>().SetBool("DoSlow", false);
            Time.timeScale += (1f / slowDownLenght) * (Time.unscaledDeltaTime);
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1.0f);

            if (Time.timeScale == 1.0f)
            {
                Time.fixedDeltaTime = Time.deltaTime;
                girdi = false;
            }
        }



        

    }

    public void doSlowMotion ()
    {
        Time.timeScale = slowDown;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mainCam.GetComponent<Animator>().SetBool("DoSlow", false);
            Time.timeScale = 1f;
            carpti = true;
        }
    }

}
