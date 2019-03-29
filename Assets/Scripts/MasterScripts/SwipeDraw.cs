using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Brandon's SwipeDrawer script
//draws a line along the swipe made on screen

public class SwipeDraw : MonoBehaviour {

    //private
    private LineRenderer lineRenderer; //the actual line

    private float zOffset = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        TouchMovementTester.OnSwipe += TouchMovementTester_OnSwipe;
    }

    private void TouchMovementTester_OnSwipe(TouchMovementTester.SwipeData data)
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = Camera.main.ScreenToWorldPoint(new Vector3(data.StartPosition.x, data.StartPosition.y, zOffset));
        positions[1] = Camera.main.ScreenToWorldPoint(new Vector3(data.EndPosition.x, data.EndPosition.y, zOffset));
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(positions);
    }
}