using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaking : MonoBehaviour
{
    public static CameraShaking instance;

    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;

    public float rotationMultiplier = 15f;
    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartShake(.5f, .5f);
        }
    }

    private void LateUpdate()
    {
        if(shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

           // float xAmount = Random.Range(-1, 1) * shakePower;
            //float YAmount = Random.Range(-1, 1) * shakePower;

          //  transform.position += new Vector3(xAmount, YAmount, 0f);

           // shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);

        }
        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1, 1));
    }


    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;

        shakeFadeTime = power / length;
        shakeRotation = power * rotationMultiplier;
    }

}
