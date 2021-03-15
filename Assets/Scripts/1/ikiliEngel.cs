using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ikiliEngel : MonoBehaviour
{
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameCore.instance.PerkKoruma == false)
            {
                SoundManager.playsound("Elektrik");
                //collision.gameObject.GetComponent<Rigidbody2D>().velocity += -Vector2.right * 5f;
                Debug.Log("ikiliengel");
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
