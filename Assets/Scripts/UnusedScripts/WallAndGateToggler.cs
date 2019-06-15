using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Mateusz's wallToggle script
//allows special walls to be disabled by hitting a switch
//can be configured to start the walls off either enabled or enabled
//can be configured to be activated with either batteries, dummies, or both
//attach this script to the switch and in the editor put in the wall to be toggled in either the battery or dummy slot
//can potentially have two different walls to govern if put a different wall in each slot

public class WallAndGateToggler : MonoBehaviour {

    //public
    public GameObject battCorrespond; //object for switches activated by batteries

    public GameObject dummCorrespond; //object for switches activated by dummies

    public bool trig; //used for checking if wall is active at start and set colors/triggers accordingly

    //private
    private Color off; //grey for deactivated

    private Color on; //seafoam green for on 

    //other
    SpriteRenderer s; //color of the switch

	// Use this for initialization
	void Start () {
        off = Color.gray;

        s = gameObject.GetComponent<SpriteRenderer>();
        s.color = new Color(1f, 0.6f, 0f);

        //which ever option is unused is set to an empty object
        //should always have at least one filled with an actual wall
        if(battCorrespond == null) //dummy is filled
        {
            //the empty object
            battCorrespond = new GameObject();
            battCorrespond.tag = "placebo";

            //dummy switch is red
            s.color = new Color(0.5f, 0f, 0f);

            dummCorrespond.GetComponent<BoxCollider2D>().isTrigger = trig;
            on = dummCorrespond.GetComponent<SpriteRenderer>().color; //store color of object, gunna be a green anyway

            if(trig == true) //wall starts off deactivated
            {
                dummCorrespond.GetComponent<SpriteRenderer>().color = off;
            }
        }
        else if(dummCorrespond == null) //battery is filled
        {
            //the empty object
            dummCorrespond = new GameObject();
            dummCorrespond.tag = "placebo";

            //battery switch is yellow
            s.color = Color.yellow;

            battCorrespond.GetComponent<BoxCollider2D>().isTrigger = trig;
            on = battCorrespond.GetComponent<SpriteRenderer>().color; //store color of object, gunna be a green anyway

            if (trig == true) //wall starts off deactivated
            {
                battCorrespond.GetComponent<SpriteRenderer>().color = off;
            }
        }
        else //both are filled, and the switch is left as its original orange color
        {
            on = battCorrespond.GetComponent<SpriteRenderer>().color; //grab the on color

            //temporarily grab dummCorresponds trigger to see if its activated or not
            dummCorrespond.GetComponent<BoxCollider2D>().isTrigger = trig;
            if(trig == true)
            {
                dummCorrespond.GetComponent<SpriteRenderer>().color = off;
            }

            //temporarily grab battCorresponds trigger to see if its activated or not
            battCorrespond.GetComponent<BoxCollider2D>().isTrigger = trig;
            if (trig == true)
            {
                battCorrespond.GetComponent<SpriteRenderer>().color = off;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //checks what object hits the switch
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if both dumm and batt corresponds are filled, both of these options will be valid
        //the placebo tag prevents an empty object from being toggled by whatever unenabled option

        //if a battery hits the switch with a battCorrespond, toggle the wall
        if ((collision.gameObject.tag == "Battery" || collision.gameObject.tag == "Battery 2") && battCorrespond.tag != "placebo")
        {
            trig = battCorrespond.GetComponent<BoxCollider2D>().isTrigger; //for if more than one switch corresponds to a single wall
            if (trig == false) //disable wall
            {
                battCorrespond.GetComponent<BoxCollider2D>().isTrigger = true;
                battCorrespond.GetComponent<SpriteRenderer>().color = off;
            }
            else //enable wall
            {
                battCorrespond.GetComponent<BoxCollider2D>().isTrigger = false;
                battCorrespond.GetComponent<SpriteRenderer>().color = on;
            }
            trig = !trig; //invert the trigger
        }

        //if a dummy hits the switch with a dummCorrespond, toggle the wall
        if (collision.gameObject.tag == "dummy" && dummCorrespond.tag != "placebo")
        {
            trig = dummCorrespond.GetComponent<BoxCollider2D>().isTrigger; //for if more than one switch corresponds to a single wall
            if (trig == false) //disable wall
            {
                dummCorrespond.GetComponent<BoxCollider2D>().isTrigger = true;
                dummCorrespond.GetComponent<SpriteRenderer>().color = off;
            }
            else //enable wall
            {
                dummCorrespond.GetComponent<BoxCollider2D>().isTrigger = false;
                dummCorrespond.GetComponent<SpriteRenderer>().color = on;
            }
            trig = !trig; //invert the trigger
        }
    }
}