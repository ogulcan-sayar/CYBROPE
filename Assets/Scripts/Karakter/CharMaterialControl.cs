using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMaterialControl : MonoBehaviour
{
    //public Material yanmaEffect;
    public bool startYanmaEffect;
    private float _lavEffectY = 0.51f;
    public BoxCollider2D tabanCol;


    // Update is called once per frame
    void Update()
    {
        if (startYanmaEffect == true) 
        {
            float posX = gameObject.transform.position.x;
            transform.position=Vector3.MoveTowards(gameObject.transform.position, new Vector3(posX, -19.53f, gameObject.transform.position.z), 2f * Time.deltaTime);
            
            transform.Rotate(0, 0, 50 * Time.deltaTime);
            if(transform.position.y == -19.53f && GameCore.instance.charDead == false)
            {

                GameCore.instance.Dead();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LavMachine"))
        {
            GameCore.instance.ZıplamaButon.SetActive(false);
            gameObject.GetComponent<CharacterControl>().enabled = false;
            //gameObject.GetComponent<SpriteRenderer>().material = yanmaEffect;
            StartCoroutine(lavCokus());
        }
    }

    void YanmaEffect()
    {

    }

    IEnumerator lavCokus()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        yield return new WaitForSeconds(.1f);
        tabanCol.isTrigger = true;
        startYanmaEffect = true;
        /*for(int i=0;i < 90; i++)
        {
            //gameObject.transform.rotation = Quaternion.Euler(0, 0, i);
            //gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.05f);
            _lavEffectY -= 0.004f;
            yanmaEffect.SetVector("_lavEffect", new Vector2(0.28f, _lavEffectY));
            yield return new WaitForSeconds(Time.deltaTime*5);
        }*/
        //yield return new WaitForSeconds(1f);



    }
}
