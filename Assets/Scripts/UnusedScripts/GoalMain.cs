using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Based off of Mateusz's goal script and Brandon's BatteryBehavior script
//Attach this to the goal panels
//signals the completion of the level when main battery reaches the goal
//goes back to main menu upon winning

public class GoalMain : MonoBehaviour {

    //public
    public ObjectMovement script; //this is the ObjectMovement script of the associated battery

    public Transform battery; //this is the transform of the associated battery

    public Transform goal; //This is the transform of the current goal panel

    /*
     * Maybe use the battery object name instead of tag?
     */
    public string batteryTag; //this is the tag of the associated battery, and is the only battery compatible with this battery

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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if the object has the same stored tag and the same rotation as the goal, then it enters the first if statement
        //for rotation levels, the battery should have the same rotation as the goal to activate a win
        if(collision.gameObject.tag == batteryTag && battery.rotation == goal.rotation && script.charged == true)
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

            //call the win method
            win();
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

    void win()
    {
        /*
         * May have to chance which scene it leads to or at least add a canvas 
         * sayin YOU WIN that lingers for a few seconds before going scraight to
         * the main menu
         */
        SceneManager.LoadScene("level select");//"MainMenu");
    }
}