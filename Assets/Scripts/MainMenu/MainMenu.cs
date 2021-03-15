using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator LoadingScene;
    public AudioSource anaMüzik;
    public void GameStart()
    {
        StartCoroutine(GameStartEnum());
    }

    IEnumerator GameStartEnum()
    {
        anaMüzik.volume = 0;
        LoadingScene.gameObject.SetActive(true);
        LoadingScene.SetTrigger("baslat");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
