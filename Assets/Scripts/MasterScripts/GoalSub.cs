using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Mateusz's subGoal script and Brandon's BatteryBehavior script
//attach this to the sub goal panels
//signals other scripts to run once the secondary battery reaches its subgoal
//any other script can look in on the activate boolean

public class GoalSub : MonoBehaviour {

    //public
    public ObjectMovement script; //this is the ObjectMovement script of the associated battery

    public Transform battery; //this is the transform of the associated battery

    public Transform goal; //This is the transform of the current goal panel

    public string batteryTag; //this is the tag of the associated battery, and is the only battery compatible with this battery

    public bool activate; //bool used to tell scripts looking at this one to activate and run

    //other
    Vector3 b; //vector value for the battery

    Vector3 g; //vector value for the goal panel

    Collider2D c; //collider for the goal panel

    // Use this for initialization
    void Start () {
        b = battery.position;
        g = goal.position;
        c = GetComponent<Collider2D>();
        batteryTag = battery.tag;
        activate = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if the object has the same stored tag and the same rotation as the goal, then it enters the first if statement
        //for rotation levels, the battery should have the same rotation as the goal to activate a win
        if (collision.gameObject.tag == batteryTag && battery.rotation == goal.rotation && script.charged == true)
        {
            //disable input ability of the battery
            script.enable = false;

            //make the battery intangible
            battery.GetComponent<Collider2D>().isTrigger = true;

            //set x and y of the battery vector to the x and y of the goal vector
            b.x = g.x;
            b.y = g.y;

            //set the battery position to the new vector
            /*
             * maybe just set it to g vector?
             */
            battery.position = b;

            //set the x and y values to 0, and revert the movement bool back to false
            script.x = 0f;
            script.y = 0f;
            script.check.moving = false;

            //turn on the activate boolean
            activate = true;
        }
        else
        {
            //make the goal intanglible so that non battery objects will just pass through
            c.isTrigger = true;
        }
    }

    //once non battery objects pass through, revert goal panel back to a solid
    void OnTriggerExit2D(Collider2D collision)
    {
        c.isTrigger = false;
    }
}
