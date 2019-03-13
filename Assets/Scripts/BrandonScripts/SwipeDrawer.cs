using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private float zOffset = 10;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        TouchMovementTest.OnSwipe += TouchMovementTest_OnSwipe;
    }

    private void TouchMovementTest_OnSwipe(TouchMovementTest.SwipeData data)
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = Camera.main.ScreenToWorldPoint(new Vector3(data.StartPosition.x, data.StartPosition.y, zOffset));
        positions[1] = Camera.main.ScreenToWorldPoint(new Vector3(data.EndPosition.x, data.EndPosition.y, zOffset));
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(positions);
    }
}
