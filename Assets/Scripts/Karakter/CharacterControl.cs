using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    Animator anim;
    SwipeScript swipe;
    DistanceJoint2D joint;
    public GameObject kol;
    public float movementSpeed;
    RaycastHit2D hit;
    Rigidbody2D charRigid;
    private BoxCollider2D boxCol2d;
    public LayerMask mask;
    public LayerMask ground;
    public GameObject ipinAtilacagiYer;
    private bool ipAtildi;
    private bool ziplaButtonBasildi;
    
    private bool engeleCarpti;
    public bool set_engeleCarpti { set { engeleCarpti = value; } }



    void Start()
    {
        kol.SetActive(false);
        anim = gameObject.GetComponent<Animator>();
        boxCol2d = transform.GetComponent<BoxCollider2D>();
        charRigid = gameObject.GetComponent<Rigidbody2D>();
        swipe = gameObject.GetComponent<SwipeScript>();
        joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        ipAtildi = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsGrounded()+ "asd");
        //RefreshCollider();
        if (GameCore.instance.gameType==0)
        {
            anim.SetInteger("GameType", 0);
            swipeControl();

        }

        else if (GameCore.instance.gameType == 1)
        {
            anim.SetInteger("GameType", 1);
            Walk();
        }
    }



    public void ipAt()
    {
        //
        Vector3 vectorToTarget = ipinAtilacagiYer.transform.position - kol.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        kol.transform.rotation = Quaternion.Slerp(kol.transform.rotation, q, Time.deltaTime * 15f);
        //Kolu döndürmek için
        Line.instance.ipiOlustur(kol.transform.Find("Kolucu").transform.position, hit.point);

        /*if(swipe.Swipe == true) // swipe yaparsa ipi hızlandırmak için
        {
            
            swipe.ResetSwipe();
        }*/
        if (ipAtildi == false)
        {
            SoundManager.playsound("ipAtma");
            ipAtildi = true;
            joint.enabled = true;
            
            hit = Physics2D.Raycast(transform.position, new Vector2(1.2f, 1), Mathf.Infinity, mask);

            if (hit.collider != null)
            {
                ipinAtilacagiYer.transform.position = hit.point;
                ipinAtilacagiYer.transform.Find("Spark").GetComponent<ParticleSystem>().Play();
                joint.connectedBody = ipinAtilacagiYer.GetComponent<Rigidbody2D>();      
            }
            charRigid.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);
            
            if(charRigid.velocity.x < 10f)
            {
                Vector2 velocty = new Vector2(18, charRigid.velocity.y);
                charRigid.velocity = velocty;
            }
            if (charRigid.velocity.y > 0f)
            {
                Vector2 velocty = new Vector2(charRigid.velocity.x, 0f);
                charRigid.velocity = velocty;
            }
        }


    }   
    public void ipiBirak()
    {
    
        if(Line.instance.ipKesildi != true)
        {

            Line.instance.ipiSal();
        }
        
        if (ipAtildi==true)
        {
            
            charRigid.velocity += Vector2.up * 3f;
        }

        joint.connectedBody = null;
        joint.enabled = false;
        ipAtildi = false;


    }

    public bool IsGrounded()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(boxCol2d.bounds.center, boxCol2d.bounds.size, 0f, Vector2.down, .1f, ground);

        return raycast.collider != null;
    }

    public void swipeControl ()
    {
        if (IsGrounded() == false)
        {
    
               // kol.SetActive(true);

           

            if (swipe.Hold == true && ziplaButtonBasildi==false)
            {
                anim.SetBool("ipAtildi", true);
                ipAt();
            }
            else
            {
                //
                Vector3 vectorToTarget = Vector2.right;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                kol.transform.rotation = Quaternion.Slerp(kol.transform.rotation, q, Time.deltaTime * 10f);
                //Kolu döndürmek için
                anim.SetBool("ipAtildi", false);
                
                ipiBirak();
            }
        }

    }






    public void Walk()
    {
      //  kol.SetActive(false);
        joint.connectedBody = null;
        joint.enabled = false;
        ipAtildi = false;
        Line.instance.ipiSal();
        SetGravity(5f);
        if (IsGrounded()) {
            
            swipe.enabled = true;
            SetGravity(1f);
            if (IsGrounded() && swipe.SwipeUp)
            {
                SoundManager.playsound("ziplama");
                SetGravity(5f);
                anim.SetTrigger("Zipla");
                swipe.ResetSwipe();
                swipe.enabled = false;

                if (engeleCarpti == false )
                {
                    charRigid.velocity = new Vector2(0, 20f);
                    charRigid.velocity = new Vector2(movementSpeed, charRigid.velocity.y);
                }else 
                {
                    StartCoroutine(Zipla());
                }
             
            }

            else if (swipe.SwipeDown)
            {
                
                swipe.ResetSwipe();
                swipe.enabled = false;
                anim.SetTrigger("Eğil");
                charRigid.velocity = new Vector2(movementSpeed, charRigid.velocity.y);

            }
            else
            {
               if(engeleCarpti == false)
                {
                    SoundManager.playsound("yurume");
                    charRigid.velocity = new Vector2(movementSpeed, charRigid.velocity.y);
                }
              
            }
            
        }

    }

    public void SetGravity(float a)
    {
        charRigid.gravityScale = a;
    }

    IEnumerator Zipla()
    {
        charRigid.velocity = new Vector2(0, 20f);
        yield return new WaitForSeconds(0.3f);
        charRigid.velocity = new Vector2(movementSpeed, charRigid.velocity.y);

    }


    public void ziplaButton(bool zipla)
    {
        if(GameCore.instance.gameType==0)
        { 
            if (zipla==true)
            {


                anim.SetBool("ButtonZipla", true);
                swipe.ResetSwipe();
                swipe.ResetHold();
                swipe.enabled = false;
                ziplaButtonBasildi = true;
                Debug.Log(ziplaButtonBasildi);
                joint.connectedBody = null;
                joint.enabled = false;
                ipAtildi = false;
                Line.instance.ipiSal();
                //SoundManager.playsound("ziplama");
                kol.SetActive(false);
                charRigid.velocity = new Vector2(0, 20f);
                charRigid.velocity = new Vector2(movementSpeed, charRigid.velocity.y);

            }
            else
            {
                Debug.Log("else");
                anim.SetBool("ButtonZipla", false);
                kol.SetActive(true);
                ziplaButtonBasildi = false;
                swipe.enabled = true;
                GameCore.instance.buttonCoolDown = 0f;
            }
        }
    }

}
