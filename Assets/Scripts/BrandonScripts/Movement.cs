using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float x;
    public float y;
    public float z;

    Vector3 newSpot;

    // Use this for initialization
    void Start ()
    {
        newSpot = new Vector3(x, y, z);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Move()
    {
        transform.localPosition = newSpot;
    }
}
