using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfektliZiplatma : HavaEngeliZiplatmaScript
{
    public ParticleSystem ZiplatmaEfekti;


    

    protected override IEnumerator StartSwipe()
    {
        ZiplatmaEfekti.Play();
        yield return StartCoroutine(base.StartSwipe());
    }


}
