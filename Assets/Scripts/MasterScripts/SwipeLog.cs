using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Brandon's SwipeLogger script
//Keeps track of touch screen swipes

public class SwipeLog : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //logs each swipe
    private void Awake()
    {
        TouchMovementTester.OnSwipe += TouchMovementTester_OnSwipe;
    }


    //keeps track of what direction each swipe is on the console
    private void TouchMovementTester_OnSwipe(TouchMovementTester.SwipeData data)
    {
        Debug.Log("Swipe in Direction: " + data.Direction);
    }
}