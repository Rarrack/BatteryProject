using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeLogger : MonoBehaviour
{

    private void Awake()
    {
        TouchMovementTest.OnSwipe += TouchMovementTest_OnSwipe;
    }

    private void TouchMovementTest_OnSwipe(TouchMovementTest.SwipeData data)
    {
        Debug.Log("Swipe in Direction: " + data.Direction);
    }
}
