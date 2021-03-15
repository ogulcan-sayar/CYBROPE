using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneRainScript : MonoBehaviour
{
    private bool Baslat;
    public float minDistance,maxDistance;
    public float tasAraligi;
    public GameObject[] Taslar = new GameObject[3];
    private GameObject Player;
    private float timer;
    public ParticleSystem StoneFX;
    [HideInInspector] public PoolPattern stoneRainPool;
    static public StoneRainScript instance;

    void Start()
    {
        instance = this;
        stoneRainPool = GetComponent<PoolPattern>();
        stoneRainPool.OlusturPoolPattern(Taslar, 50);
        
        Player = GameObject.FindGameObjectWithTag("Player");
        StoneFX.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Baslat == true)
        {
            stoneRainPool.ShowCount();
            timer += Time.deltaTime;
            if(Player.transform.position.x < maxDistance)
            {
                if (timer >= .4f)
                {
                    if(Player.transform.position.x < (maxDistance + minDistance) / 2) {
                        stoneRainPool.HavuzdanCek(new Vector2(Random.Range(minDistance, (maxDistance + minDistance) / 2), CameraScript.instance.YMaxValue + 10), Quaternion.identity);
                        //Instantiate(Taslar[Random.Range(0, 4)], new Vector2(Random.Range(minDistance, (maxDistance+minDistance)/2), CameraScript.instance.YMaxValue  + 10), Quaternion.identity);
                    }
                    else
                    {
                        stoneRainPool.HavuzdanCek(new Vector2(Random.Range((maxDistance + minDistance) / 2, maxDistance), CameraScript.instance.YMaxValue + 10), Quaternion.identity);
                        //Instantiate(Taslar[Random.Range(0, 4)], new Vector2(Random.Range((maxDistance + minDistance) / 2, maxDistance), CameraScript.instance.YMaxValue + 10), Quaternion.identity);
                    }
                    timer = 0;
                }
            }
            else
            {
                Baslat = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StoneFX.Play();
            Baslat = true;
        }
    }

}
