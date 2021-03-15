using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YerShrukenGenerator : MonoBehaviour
{
    public float DogmaSuresi;
    public GameObject YerShrukenPrefab;
    public GameObject MainCamera;
    static public YerShrukenGenerator instance;

    private float timer;
    private Vector2 StartPos;
    private GameObject YerShruken;
    [HideInInspector] public bool yerShrukenOlustur;
    private bool Baslat;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        yerShrukenOlustur = true;
        timer = DogmaSuresi;
    }

    // Update is called once per frame
    void Update()
    {
        if (Baslat)
        {
            timer -= Time.deltaTime;

            if (timer <= 0 && yerShrukenOlustur == true)
            {
                CreateYerShruken();

                yerShrukenOlustur = false;
            }
        }
        else
        {
            if (YerShruken != null)
            {
                Destroy(YerShruken);
            }
        }
    }

    private void CreateYerShruken()
    {
        StartPos = MainCamera.GetComponent<Camera>().WorldToViewportPoint(StartPos);
        StartPos.x = 1.1f;
        StartPos.y = Random.Range(0.1f, 0.4f);
        StartPos = MainCamera.GetComponent<Camera>().ViewportToWorldPoint(StartPos);
        YerShruken = Instantiate(YerShrukenPrefab, StartPos, Quaternion.identity);
    }

    public void ResetYerShruken()
    {
        yerShrukenOlustur = true;
        timer = DogmaSuresi;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Baslat = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Baslat = false;
        }
    }
}
