using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Positioning Variables

    Vector3 firstSpot;
    Vector3 newSpot;
    public float x;
    public float y;
    public float z;

    #endregion

    float secs = 1.5f;
    float t;
    bool active = false;

    

    // Use this for initialization
    void Start()
    {
        firstSpot = transform.localPosition;
        newSpot = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            t += Time.deltaTime / secs;
            transform.localPosition = Vector3.Lerp(firstSpot, newSpot, t);
        }
    }

    public void Move()
    {
        active = true;
    }
}
