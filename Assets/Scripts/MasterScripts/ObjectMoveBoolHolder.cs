using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based on Mateusz's moveBoolHolder script
//Holds the universal moving bool
//while false any one movable object can be moved
//If true then nothing can be moved until the current object stops moving


public class ObjectMoveBoolHolder : MonoBehaviour {

    //public
    public bool moving;

	// Use this for initialization
	void Start () {
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
