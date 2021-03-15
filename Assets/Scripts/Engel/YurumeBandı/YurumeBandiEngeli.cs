using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YurumeBandiEngeli : MonoBehaviour
{
    public Transform bitisNoktasi;
    public float speed;
    void Start()
    {
        bitisNoktasi = gameObject.transform.parent.transform.Find("Bitis");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, bitisNoktasi.position, speed * Time.deltaTime);
        if(transform.position.x == bitisNoktasi.position.x)
        {
            Destroy(gameObject);
        }
    }
}
