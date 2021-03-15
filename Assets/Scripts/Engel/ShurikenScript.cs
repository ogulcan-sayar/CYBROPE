using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    private float timer;
    public float speed=1;
    private int direction = 1;
    Vector2 pos;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >=0.4f )
        {
            direction = -direction;
            timer = 0;

        }

        pos = gameObject.transform.position;
        pos.y += direction * speed * Time.deltaTime;
        pos.x = gameObject.transform.position.x;

        gameObject.transform.position = pos;
        transform.Rotate(0, 0, 360 * Time.deltaTime);
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("shurikenscript");
            GameCore.instance.Dead();
        }
    }
}
