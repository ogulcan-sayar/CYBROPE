using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekliEngelScript : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -360 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameCore.instance.PerkKoruma == false)
            {
                SoundManager.playsound("Elektrik");
                //collision.gameObject.GetComponent<Rigidbody2D>().velocity += -Vector2.right * 5f;
                Debug.Log("tekliengel");
                GameCore.instance.Dead();
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
