using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Brandon's Movement script
//Moves the wall attatched to this gameobject
//Called from ActivateWallMove once activate bool is on
//set the desired x, y, and z coordinates outside in the editor

public class WallMove : MonoBehaviour
{
    #region Positioning Variables

    Vector3 firstSpot; //initial position

    Vector3 newSpot; //new position

    public float x; //the designated x spot to end up at

    public float y; //the designated y spot to end up at

    public float z; //the designated z spot to end up at

    public bool coupled; //check to see if wall starts coupled
    #endregion

    float secs = 0.25f; //set variable for time formula

    float t; //container for formula that sets the rate at how fast the wall will move

    bool active = false; //tells when to run the code in update(),

    // Use this for initialization
    void Start () 
    {
        firstSpot = transform.localPosition; //store initial position

        newSpot = new Vector3(x, y, z); //store new position
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(active == true && transform.localPosition != newSpot)
        {
            t += Time.deltaTime / secs; //rate formula
            transform.localPosition = Vector3.Lerp(firstSpot, newSpot, t); //move to new position at the specified rate of t
        }
	}

    // Function for activating wall movement
    public void Move()
    {
        coupled = !coupled;
        if(coupled == true)
        {
            GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Uncouple");
        }
        else
        {
            GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Couple");
        }

        active = true; // Allows active to be set from outside of script
    }
}