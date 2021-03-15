using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour
{
    private bool swipeLeft, swipeRight, swipeUp, swipeDown, hold, swipe;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } set {swipeUp = value; } }
    public bool Hold { get { return hold; } set { hold = value; } }
    public bool Swipe { get { return swipe; } set { swipe = value; } }
    public bool SwipeDown { get { return swipeDown; } set { swipeDown = value; } }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            hold = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
  
        else if(Input.GetMouseButtonUp(0))
        {
            hold = false;
            isDraging = false;
            Reset();
        }
        #endregion
        #region Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                hold = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {

                hold = false;      
                isDraging = false;
                Reset();
            }
        }
        #endregion

        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if(swipeDelta.magnitude > 125)
        {
            swipe = true;
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            hold = true;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if(x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else
            {

                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }

            Reset();
        }
        //swipeLeft = swipeRight = swipeUp = swipeDown = false;
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    public void ResetSwipe()
    {
        swipe=swipeLeft = swipeRight = swipeUp = swipeDown = false;
    }

    public void ResetHold()
    {
        hold = false;
    }

}
