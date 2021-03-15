using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPointScript : MonoBehaviour
{
    private float timer;
    public float speed = 0.5f;
    void Start()
    {
        timer = 0;      
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime *6;
        if ((int)timer % 2 == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
