using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public float minTime;
    public float maxTime;
    public GameObject MainCamera;
    public GameObject CreatePoint;
    public GameObject RocketPrefab;

    private float ChosenTime;
    public static float timer=0;
    private int direction;
    public static bool youcanChoose;
    public static bool youcanCreate;
    private bool PointOlusturuldu;
    Vector2 StartPos;
    GameObject RocketPoint;
    GameObject Rocket;
    private bool sesiVer;
    [HideInInspector] public PoolPattern poolRocketPoint;
    [HideInInspector] public PoolPattern poolRocket;

    public static RocketScript instance;

    void Start()
    {
        instance = this;
       // poolRocketPoint = new PoolPattern(CreatePoint, 1);
       // poolRocket = new PoolPattern(RocketPrefab, 1);
        poolRocketPoint = GetComponents<PoolPattern>()[0];
        poolRocket = GetComponents<PoolPattern>()[1];
        poolRocketPoint.OlusturPoolPattern(CreatePoint, 1);
        poolRocket.OlusturPoolPattern(RocketPrefab, 1);
        direction = 1;
        youcanChoose = true;
        youcanCreate = true;
        sesiVer = true;
    }

    void Update()
    {
        if (GameCore.instance.gameType == 0)
        {
            timer += Time.deltaTime;
            if (timer >= ChooseTime(maxTime, minTime) && youcanCreate == true)
            {
                youcanCreate = false;
                CreateRandomPoint();



                timer = 0;
                youcanChoose = true;
            }
            else if (PointOlusturuldu == true && RocketPoint != null)
            {
                
                youcanChoose = true;
                Vector2 pos = RocketPoint.transform.position;
                pos.y = Mathf.Lerp(pos.y, GameObject.FindGameObjectWithTag("Player").transform.position.y, 5f * Time.deltaTime);             
                if (timer >= ChooseTime(5, 10) && RocketPoint != null)
                {
                    StartCoroutine(CreateRocket());
                }
                pos = MainCamera.GetComponent<Camera>().WorldToViewportPoint(pos);
                pos.x = 0.98f;
                pos = MainCamera.GetComponent<Camera>().ViewportToWorldPoint(pos);
                RocketPoint.transform.position = pos;
            }
        }
        else
        {
            timer = 0;

            if (Rocket != null && Rocket.activeSelf == true)
            {
                poolRocket.HavuzaObjeEkle(Rocket);
                // Destroy(Rocket);
            }
            else if (RocketPoint != null && RocketPoint.activeSelf == true)
            {
                
                poolRocketPoint.HavuzaObjeEkle(RocketPoint);
                
                //  Destroy(RocketPoint);
            }
        }
    }



    private float ChooseTime(float a, float b)
    {
        if (youcanChoose == true) {
            ChosenTime = Random.Range(a, b);
            youcanChoose = false;
            return ChosenTime;
        }
        else
            return ChosenTime;

    }

    private void CreateRandomPoint() 
    {

        StartPos = MainCamera.GetComponent<Camera>().WorldToViewportPoint(StartPos);
        StartPos.x = 1.1f;
        StartPos.y = Random.Range(0.1f, .9f);
        StartPos = MainCamera.GetComponent<Camera>().ViewportToWorldPoint(StartPos);

        /*StartPos = new Vector2(MainCamera.transform.position.x + 100,Random.Range(MainCamera.GetComponent<CameraScript>().YMinValue+2f, MainCamera.GetComponent<CameraScript>().YMaxValue-2) );
        StartPos = MainCamera.GetComponent<Camera>().WorldToViewportPoint(StartPos);
        StartPos.x = 1;*/
        RocketPoint = poolRocketPoint.HavuzdanCek(StartPos, Quaternion.identity);
        //RocketPoint =Instantiate(CreatePoint, StartPos, Quaternion.identity);
        PointOlusturuldu = true;
        timer = 0;
    }
    IEnumerator CreateRocket()
    {
        if (sesiVer == true)
        {
            SoundManager.playsound("roketSayac");
            sesiVer = false;
        }
            RocketPoint.GetComponent<RocketPointScript>().speed = 3;
            yield return new WaitForSeconds(1);
            if (RocketPoint.activeSelf == true)
            Rocket = poolRocket.HavuzdanCek(new Vector2(RocketPoint.transform.position.x + 5, RocketPoint.transform.position.y), Quaternion.identity);
            //Rocket = Instantiate(RocketPrefab, new Vector2(RocketPoint.transform.position.x + 5, RocketPoint.transform.position.y), Quaternion.identity);
            poolRocketPoint.HavuzaObjeEkle(RocketPoint);
            //Destroy(RocketPoint);
            PointOlusturuldu = false;
        sesiVer = true;
    }

    public static void ResetRocket()
    {
        youcanCreate = true;
        timer = 0;
        youcanChoose = true;
    }
}
