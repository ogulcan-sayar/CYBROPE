using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Collectible : MonoBehaviour
{

    public TextMeshProUGUI pointText;


    void Start()
    {
        //instance = this;
        pointText = GameCore.instance.Canvas.transform.Find("Points_Parent").transform.Find("Points").GetComponent<TextMeshProUGUI>();
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player" && GameCore.instance.charDead == false)
        {
            SoundManager.playsound("Point");
            GameCore.instance.extraPoint(20f);
            PuanAnimasyonu();
            Destroy(gameObject);

        }
    }

    void PuanAnimasyonu()
    {
        Vector2 pos;
        pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        pos.y -= 200f;
        pointText.gameObject.transform.parent.transform.position = pos;

        pointText.text = "+" + 20f;
        pointText.gameObject.GetComponent<Animator>().SetTrigger("alindi");
    }


}
