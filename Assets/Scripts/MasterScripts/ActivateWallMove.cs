using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Brandon's MoveWall
//Looks for the activation of the sub goal activate bool in order to run
//shifts walls to new positions when activated

public class ActivateWallMove : MonoBehaviour {

    //publics
    public List<GameObject> walls; //list of wall objects that shall be moved
    public GoalSub script; //script where the activation boolean will be set

    //privates
    private bool setup1; //prevents movable walls from being added repeatedly
    private bool setup2; //prevents movable walls from moving repeatedly after activation

	// Use this for initialization
	void Start () {
        setup1 = false;
        setup2 = false;
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * put into Start() and get rid of setup1 logic. make setup2 the only setup bool
         * no need for the setup1 bool then
         */
        //adds all objects with the tag Moveable Walls to the walls list
        //once done the setup1 bool prevents it from running again
		if(GameObject.Find("Moveable Walls") != null && setup1 != true)
        {
            for(int i = 0; i < GameObject.Find("Moveable Walls").transform.childCount; i++)
            {
                walls.Add(GameObject.Find("Moveable Walls").transform.GetChild(i).gameObject);
            }

            if(walls != null)
            {
                setup1 = true;
            }
        }

        //moves all walls to new positions once the activate bool is set to true in GoalSub
        //once done the setup2 bool prevents it from running again
        if(script.activate == true && setup2 != true)
        {
            for(int i = 0; i < walls.Count; i++)
            {
                walls[i].GetComponent<WallMove>().active = true;
            }

            setup2 = true;
        }
	}
}