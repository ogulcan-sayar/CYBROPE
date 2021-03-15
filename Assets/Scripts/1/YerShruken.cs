using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YerShruken : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * 10f * Time.deltaTime, Space.World);
        transform.Rotate(0, 0, 3000 * Time.deltaTime);

        KameraKontrol();
    }

    void KameraKontrol()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > -0.05f && screenPoint.x < 1.5f && screenPoint.y > 0 && screenPoint.y < 1;

        if (!onScreen)
        {
            YerShrukenGenerator.instance.ResetYerShruken();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            YerShrukenGenerator.instance.ResetYerShruken();
            Destroy(gameObject);
            Debug.Log("yershuriken");
            GameCore.instance.Dead();
        }
       
    }

}
