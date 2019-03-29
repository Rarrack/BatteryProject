using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Mateusz's unlocker script
//attach to a wall object, and put in the switches in the array that it will be looking at to activate
//currently all trigs of the scripts that it looks at have to be set to false

public class WallAndGateUnlocker : MonoBehaviour {

    //public
    public List<WallAndGateToggler> keys; //list of WallAndGateToggler scripts

    public bool unlock; //bool that controls when to deactivate the wall

    //private
    private Color off; //grey for off

    private Color on; //seafoam green for on

	// Use this for initialization
	void Start () {
        off = Color.gray;

        on = gameObject.GetComponent<SpriteRenderer>().color;

        unlock = false;
	}
	
	// Update is called once per frame
	void Update () { //continually checks if all the trigs of the scripts in the list are false
        foreach(WallAndGateToggler key in keys)
        {
            if(key.trig == true) //if even one trig is still true, set unlock to false and exit the loop
            {
                unlock = false;
                break;
            }
            else //if trig is false, set unlock to true. if all trigs are false then unlock will stay true
            {
                unlock = true;
            }
        }

        if(unlock == true) //if all trigs are false then wall is disabled
        {
            gameObject.GetComponent<SpriteRenderer>().color = off;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else //can still be set to locked if any of the trigs are set back to true
        {
            gameObject.GetComponent<SpriteRenderer>().color = on;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}