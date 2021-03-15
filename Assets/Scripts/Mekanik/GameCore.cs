using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class GameCore : MonoBehaviour

    
{
    public GameObject Player;
    public GameObject Canvas;
    public Slider gameDistance;
    public float[] gameDistanceValues;
    public int gameType=1;
    public Animator deadAnim;
    public Animator gameEnding;
    public static GameCore instance;
    public bool charDead;
    [HideInInspector] public bool PerkKoruma;
    [HideInInspector] public GameObject PerkKorumaObj;
    public AudioSource anaMuzik;
    public AudioSource audioFX;
    public static bool tekrardanOynaniliyor;
    public GameObject ZıplamaButon;
    public Image ZıplamaButtonImage;
    public float buttonCoolDown;
    [HideInInspector] public bool buttonIsActive;

    public Text HighScoreText;
    public TextMeshProUGUI ScoreText;
    private static float HighScore;
    private float tempHighScore;
    private float gameDistancePoints;
    private float gameCollectiblePoints;

    private float Kalkantimer;
    public float KalkanTime;
    float transparentKalkan = 118f;

    public int levelIndex;

    void Start()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        ZıplamaButon.SetActive(false);
        instance = this;
        Application.targetFrameRate = 60;
        setGameDistanceBar(gameDistanceValues[0], gameDistanceValues[1]);
        buttonIsActive = true;
        Kalkantimer = KalkanTime;
    }

    // Update is called once per frame
    void Update()
    {
        ZiplamaButtonMethod();
        KalkanPerkKontrol();


        if (charDead == true)
        {
            anaMuzik.pitch -= Time.deltaTime * 0.2f;
            if (anaMuzik.pitch <= 0)
            {
                anaMuzik.pitch = 0;
            }
        }
        if (charDead == false)
        {
            gameDistance.value = Player.transform.position.x;
        }
        ShowScore();
    }


    public  void Dead ()
    {
        if (charDead == false)
        {
            
            StartCoroutine(DeadEnum());
        }


    }

    IEnumerator DeadEnum()
    {
        ZıplamaButon.SetActive(false);
        audioFX.volume = 0;
        SoundManager.playsound("olum");
        gameDistance.gameObject.GetComponent<Animator>().SetTrigger("öldü");
        Player.GetComponent<SwipeScript>().enabled = false;
        Player.GetComponent<CharacterControl>().ipiBirak();
        Player.GetComponent<Animator>().enabled = false;
        if(GameCore.instance.gameType == 1)
        {
            Player.GetComponent<Rigidbody2D>().velocity = -Vector2.right * 8f;
        }
        else
        {
            Player.GetComponent<Rigidbody2D>().velocity = -Vector2.up * 8f;
        }
        Player.GetComponent<CharacterControl>().enabled = false;
        
        ScoreText.gameObject.SetActive(false);
        
        
        //audioFX.gameObject.SetActive(false);
        
        charDead = true;
       tekrardanOynaniliyor = true;
        deadAnim.SetTrigger("öldü");
        setHighScore();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Finishing()
    {
        StartCoroutine(FinishingEnum());
    }

    IEnumerator FinishingEnum()
    {
        
        deadAnim.SetTrigger("öldü");
        ScoreText.gameObject.SetActive(false);
        setHighScore();
        yield return new WaitForSeconds(2f);
        gameEnding.SetTrigger("Bitir");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }

    public void FinishingTutorial()
    {
        StartCoroutine(FinishingTutorialEnum());
    }

    IEnumerator FinishingTutorialEnum()
    {
        gameEnding.SetTrigger("EgitimiBitir");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    void setGameDistanceBar(float min, float max)
    {
        gameDistance.minValue = min;
        gameDistance.maxValue = max;
    }

    void setHighScore()
    {
        gameDistancePoints = 49.5f + gameDistance.value;
        tempHighScore = gameCollectiblePoints + gameDistancePoints;
        
        if(tempHighScore > HighScore)
        {
            HighScore = (float)(tempHighScore);
            HighScoreText.text = "<size=50> <color=#9FDB24> EN YUKSEK SKOR! \n" + (int)HighScore +  " </color> </size> " + "\n Alinan Mesafe: " + (int)gameDistancePoints + "\n Toplanan Puanlar: " + (int)gameCollectiblePoints;

    
        }
        else
        {
            HighScoreText.text = "<size=50> <color=#9FDB24> YENI SKOR:  " + ((int)tempHighScore)+ " </color> </size> " + "\n \n Alinan Mesafe: " + (int)gameDistancePoints + "\n Toplanan Puanlar: " + (int)gameCollectiblePoints + "\n \n <size=35> <color=#9FDB24> EN YUKSEK SKOR:  " + (int)HighScore + " </color> </size>\n";

        }
        

    }

    public void extraPoint (float a)
    {
        gameCollectiblePoints += a;
    }

    public void ShowScore()
    {
        gameDistancePoints = 49.5f + gameDistance.value;
        tempHighScore = gameCollectiblePoints + gameDistancePoints;
        ScoreText.text = "" + (int)tempHighScore;
    }

    public void ResetAirPerks()
    {
        Kalkantimer = KalkanTime;
        transparentKalkan = 118f;
        PerkKoruma = false;
        Destroy(PerkKorumaObj);
    }

    public void KalkanPerkKontrol()
    {
        if (PerkKoruma == true)
        {
            Kalkantimer -= Time.deltaTime;

          
            if (Kalkantimer <= 0 && transparentKalkan <= 0)
            {
                ResetAirPerks();
            }
            else
            {
                transparentKalkan -= 20 * Time.deltaTime;
            }

            PerkKorumaObj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, (byte)transparentKalkan);
        }
    }

    void ZiplamaButtonMethod()
    {
        
        buttonCoolDown += Time.deltaTime;
        if (buttonIsActive == true)
        {
            ZıplamaButtonImage.fillAmount = buttonCoolDown / 5f;
            if (ZıplamaButtonImage.fillAmount == 1)
            {

                ZıplamaButon.GetComponent<Button>().interactable = true;
                ZıplamaButon.GetComponent<EventTrigger>().enabled = true;
            }
            else
            {
                ZıplamaButon.GetComponent<Button>().interactable = false;
                ZıplamaButon.GetComponent<EventTrigger>().enabled = false;
            }
        }
    }

}
