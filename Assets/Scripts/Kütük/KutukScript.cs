using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutukScript : MonoBehaviour
{
   // public BoxCollider2D tavanColl;
    void Start()
    {
        //Physics2D.IgnoreCollision(gameObject.GetComponent<EdgeCollider2D>(), tavanColl);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tavan"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<EdgeCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
        }
    }
}
