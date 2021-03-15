using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip lazerAtis, roketSayac, yurume, ziplama, ipAtma, olum, girisPatlama,point;
    public static AudioSource audioSrc;
    public static SoundManager instance;

    void Start()
    {
        instance = this;
        audioSrc = GetComponent<AudioSource>();

        lazerAtis = Resources.Load<AudioClip>("Müzik/AudioFx/LazerAtis");
        roketSayac = Resources.Load<AudioClip>("Müzik/AudioFx/RoketSayac");
        yurume = Resources.Load<AudioClip>("Müzik/AudioFx/Yurume");
        ziplama = Resources.Load<AudioClip>("Müzik/AudioFx/Zıplama");
        ipAtma = Resources.Load<AudioClip>("Müzik/AudioFx/İp");
        olum = Resources.Load<AudioClip>("Müzik/AudioFx/Olum");
        girisPatlama = Resources.Load<AudioClip>("Müzik/AudioFx/GirisPatlama");
        point = Resources.Load<AudioClip>("Müzik/AudioFx/Point");
        //yerShruken = Resources.Load<AudioClip>("Müzik/AudioFx/yerShruken");
        //elektrik = Resources.Load<AudioClip>("Müzik/AudioFx/Elektrik");
    }
    public static void playsound(string clip)
    {
        switch (clip)
        {
            case "lazerAtis":
                instance.gameObject.GetComponent<AudioSource>().volume = 1f;
                audioSrc.PlayOneShot(lazerAtis);
                //if (!audioSrc.isPlaying)
                    //audioSrc.PlayOneShot(lazerAtis);
                break;
            case "roketSayac":
                instance.gameObject.GetComponent<AudioSource>().volume = 1f;
                audioSrc.PlayOneShot(roketSayac);
                break;
            case "ziplama":
                instance.gameObject.GetComponent<AudioSource>().volume = 1f;
                audioSrc.PlayOneShot(ziplama);
                break;
            case "yurume":
                instance.gameObject.GetComponent<AudioSource>().volume = 1f;
                audioSrc.clip = yurume;
                if (!audioSrc.isPlaying)
                    audioSrc.Play();
                break;
            case "ipAtma":
                instance.gameObject.GetComponent<AudioSource>().volume = 1f;
                audioSrc.PlayOneShot(ipAtma);
               // if (!audioSrc.isPlaying)
                   // audioSrc.Play();
                break;
            case "olum":
                instance.gameObject.GetComponent<AudioSource>().volume = 1f;
                audioSrc.PlayOneShot(olum);
                break;
            case "girisPatlama":
                instance.gameObject.GetComponent<AudioSource>().volume = 0.5f;
                audioSrc.PlayOneShot(girisPatlama);
                break;
            case "Point":
                instance.gameObject.GetComponent<AudioSource>().volume = 1f;
                audioSrc.PlayOneShot(point);
                break;
        }
    }
}