using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [HideInInspector] public float length, startPos;
    public GameObject cam;
    public float parallaxEffect;
    [HideInInspector] public int shiftCounter;
    public float temp, dist;
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x*4;
    }

    // Update is called once per frame
    void Update()
    {
        temp = (cam.transform.position.x * (1 - parallaxEffect));
        dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        if (temp > startPos + length) 
        {
            startPos += length;
        }
        else if (temp < startPos - length) startPos -= length;

    }

    public float UzaklikAyarla(int nekadar)
    {
        

        return startPos + (nekadar*length);
    }

}
