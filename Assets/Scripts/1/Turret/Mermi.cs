using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{
    public Vector2 target;
    // Start is called before the first frame update
    public Vector2 pos;
    Vector2 dir;
    private void Awake()
    {
     
    }

    void Start()
    {

        target =new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y);
        dir = (-((Vector2)transform.position - target).normalized);

    }

    // Update is called once per frame  
    void Update()
    {
    
        shoot();
        Destroy(gameObject, 3f);
    }

    void shoot()
    {
        
         transform.Translate(dir * 10f * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PerkKalkan"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            
            if (GameCore.instance.PerkKoruma == false)
            {
                //collision.gameObject.gameObject.GetComponent<Rigidbody2D>().velocity -= new Vector2(7f, 0);
                //collision.gameObject.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
                Debug.Log("mermi");
                GameCore.instance.Dead();
                Destroy(gameObject);
            }
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PerkKalkan"))
        {
            if (GameCore.instance.PerkKoruma == true)
            {
                GameCore.instance.ResetAirPerks();
            }
        }
    }
}
