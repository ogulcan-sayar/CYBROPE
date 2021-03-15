using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float Range;
    public Transform Target;
    bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public Animator anim;
  // public GameObject alarm;
    public float turnSpeed = 5f;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.CircleCast(transform.position, Range, Direction,Range,mask);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                    //alarm.GetComponent<SpriteRenderer>().color = Color.green;
                    
                }
            }


        }
        
        if (Detected)
        {
            Gun.transform.right = -Direction * turnSpeed;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                if(GameCore.instance.gameType==0)
                {
                    SoundManager.playsound("lazerAtis");
                }
                GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
                anim.SetTrigger("Turret_Atis");
            }
        }
       
    }
    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}