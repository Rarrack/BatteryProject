using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovementTest : MonoBehaviour
{
    private Vector2 pressPosition;
    private Vector2 releasePosition;

    [SerializeField]
    private bool detectSwipeAfterRelease = false;

    [SerializeField]
    private float minSwipeDistance = 20.0f;

    public static event System.Action<SwipeData> OnSwipe = delegate { };
	
	void Update ()
    {
		foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                pressPosition = touch.position;
                releasePosition = touch.position;
            }

            if(!detectSwipeAfterRelease && touch.phase == TouchPhase.Moved)
            {
                pressPosition = touch.position;
                DetectSwipe();
            }

            if(touch.phase == TouchPhase.Ended)
            {
                pressPosition = touch.position;
                DetectSwipe();
            }
        }
	}

    private void DetectSwipe()
    {
        if(IsSwipeDistanceGood())
        {
            if(IsVerticalSwipe())
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


    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    private bool IsSwipeDistanceGood()
    {
        return VerticalMovementDistance() > minSwipeDistance || HorizontalMovementDistance() > minSwipeDistance;
    }

    private float VerticalMovementDistance()
    {
        return Mathf.Abs(pressPosition.y - releasePosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(pressPosition.x - releasePosition.x);
    }

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

    public struct SwipeData
    {
        public Vector2 StartPosition;
        public Vector2 EndPosition;
        public SwipeDirection Direction;
    }

    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right,
    }
}
