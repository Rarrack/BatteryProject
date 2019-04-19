using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Brandon's Movement script
//Moves the wall this script is attatched to to its activated spot
//Called from ActivateWallMove once activate bool is on
//set the desired x, y, and z coordinates outside in the editor

public class WallMove : MonoBehaviour {

    //public
    public float x; //the designated x spot to end up at

    public float y; //the designated y spot to end up at

    public float z; //the designated z spot to end up at

    public bool active = false; //tells when to run the code in update(),
                                //can be set from editor to test

    //other
    float secs = 0.25f; //set variable for time formula

    float t; //container for formula that sets the rate at how fast the wall will move

    Vector3 firstSpot; //initial position

    Vector3 newSpot; //new position

    // Use this for initialization
    void Start () {
        firstSpot = transform.localPosition; //store initial position

        newSpot = new Vector3(x, y, z); //store new position
	}
	
	// Update is called once per frame
	void Update () {
		if(active == true)
        {
            t += Time.deltaTime / secs; //rate formula
            transform.localPosition = Vector3.Lerp(firstSpot, newSpot, t); //move to new position at the specified rate of t

            //this doesn't really work, might need vector.equals(vector)
            /*
            if(firstSpot == newSpot)
            {
                active = false; //ensures that this doesn't run forever
            }
            */
        }
	}
}