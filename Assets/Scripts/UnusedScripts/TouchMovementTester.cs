using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Brandon's TouchMovementTest script

public class TouchMovementTester : MonoBehaviour {

    //public
    public static event System.Action<SwipeData> OnSwipe = delegate { };

    //private
    private Vector2 pressPosition; //point where swipe begins

    private Vector2 releasePosition; //point where swipe ends

    [SerializeField]
    private bool detectSwipeAfterRelease = false; //checks when swipe occurs

    [SerializeField]
    private float minSwipeDistance = 20.0f; //the minimum required distance for a swipe

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Touch touch in Input.touches)
        {
            //initial touch
            if(touch.phase == TouchPhase.Began)
            {
                pressPosition = touch.position;
                releasePosition = touch.position;
            }

            //touch has begun to move
            if(!detectSwipeAfterRelease && touch.phase == TouchPhase.Moved)
            {
                pressPosition = touch.position;
                DetectSwipe();
            }

            //no longer touching
            if(touch.phase == TouchPhase.Ended)
            {
                pressPosition = touch.position;
                DetectSwipe();
            }
        }
	}

    //check what kind of swipe has been done and then send object in the designated direction
    private void DetectSwipe()
    {
        if (IsSwipeDistanceGood())
        {
            if (IsVerticalSwipe())
            {
                var direction = pressPosition.y - releasePosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendSwipe(direction);
            }
            else
            {
                var direction = pressPosition.x - releasePosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                SendSwipe(direction);
            }
            releasePosition = pressPosition;
        }
    }

    //check if vertical or horizontal
    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    //check if the conducted swipe is of appropriate distance
    private bool IsSwipeDistanceGood()
    {
        return VerticalMovementDistance() > minSwipeDistance || HorizontalMovementDistance() > minSwipeDistance;
    }

    //calculate vertical distance for movement
    private float VerticalMovementDistance()
    {
        return Mathf.Abs(pressPosition.y - releasePosition.y);
    }

    //calculate horizontal distance for movement
    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(pressPosition.x - releasePosition.x);
    }

    //compile the direction, start and end positions of the swipe
    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            StartPosition = pressPosition,
            EndPosition = releasePosition
        };
        OnSwipe(swipeData);
    }

    //constructor/object for a swipe
    public struct SwipeData
    {
        public Vector2 StartPosition;
        public Vector2 EndPosition;
        public SwipeDirection Direction;
    }

    //contains the potential directions a swipe can be in
    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}