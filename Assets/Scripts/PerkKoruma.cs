using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkKoruma : MonoBehaviour
{
    public GameObject PrefabPerkKorumaObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameCore.instance.charDead == false)
        {
            if(GameCore.instance.PerkKoruma==true)
            {
                GameCore.instance.ResetAirPerks();
            }
            SoundManager.playsound("Point");
            GameCore.instance.PerkKoruma = true;
            GameCore.instance.PerkKorumaObj = Instantiate(PrefabPerkKorumaObj, collision.gameObject.transform.position, Quaternion.identity, collision.gameObject.transform);
            Destroy(gameObject);
        }
    }

}
