using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Mateusz's open script
//attach to objects that should disappear once the subgoal is activated

public class ActivateDisableObject : MonoBehaviour {

    //public
    public GoalSub script; //Goalsub script from corresponding subgoal

    //private
    private bool done = false; //bool check to prevent setActive being done indefinitely

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(script.activate == true && done == false) //runs only once
        {
            gameObject.SetActive(false); //disables object and makes it disappear
            done = true;

            /*
             * have a fade to dark effect like wall sliding into the bg
             */
        }
	}
}