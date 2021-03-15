using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutukGenerator : MonoBehaviour
{
    public float minTime;
    public float maxTime;
    public GameObject KutukPrefab;
    private GameObject instanKutuk;
    public ParticleSystem yaprakEffekt;
    public float YaprakDelay;

    private float timer;

    private float ChosenTime;
    private bool youcanChoose;
    private bool youcanCreate;

    private Vector2 pos;

    void Start()
    {
        yaprakEffekt.Pause();
        youcanChoose = true;
        youcanCreate = true;
    }

    void Update()
    {
        if(GameCore.instance.gameType == 0)
        {
            timer += Time.deltaTime;
            if (timer >= ChooseTime(maxTime, minTime) && youcanCreate == true)
            {
                youcanCreate = false;
                KutukOlustur();


                timer = 0;
                youcanChoose = true;
            }

        }
        else
        {
            timer = 0;

            if (instanKutuk != null)
            {
              
                Destroy(instanKutuk);
            }
            
        }
    }

    private float ChooseTime(float a, float b)
    {
        if (youcanChoose == true)
        {
            ChosenTime = Random.Range(a, b);
            youcanChoose = false;
            return ChosenTime;
        }
        else
            return ChosenTime;

    }

    private void KutukOlustur()
    {
        StartCoroutine(KutukOlusturEnum());
    }

    IEnumerator KutukOlusturEnum()
    {
        pos = Camera.main.GetComponent<Camera>().WorldToViewportPoint(pos);
        pos.x = Random.Range(1f, 1.5f);
        Debug.Log(pos.x);
        pos.y = 1.1f;
        pos = Camera.main.GetComponent<Camera>().ViewportToWorldPoint(pos);
        yaprakEffekt.gameObject.transform.position = pos;
        yaprakEffekt.Play();
        yield return new WaitForSeconds(YaprakDelay);
        instanKutuk = Instantiate(KutukPrefab, pos, Quaternion.identity);
        youcanCreate = true;
    }

}
