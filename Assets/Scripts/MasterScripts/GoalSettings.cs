using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Based off of Mateusz's goal script and Brandon's Modifications to it
//Attach this to the goal panels
//Handles goal parameters for 


public class GoalSettings : MonoBehaviour
{
    public List<GameObject> battery;
    //public  battery; //the correct battery for this goal

    Collider2D c; //collider for the goal panel

    public Sprite victorySprite;

    bool filled = false; //status if it's filled by correct battery

    //Property function for filled state
    public bool Filled
    {
        get
        {
            return filled;
        }
        set
        {
            filled = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        c = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if the object has the same stored tag and the same rotation as the goal, then it enters the first if statement
        //for rotation levels, the battery should have the same rotation as the goal to activate a win
        foreach (GameObject bat in battery)
        {
            if (collision.gameObject == bat && bat.transform.localEulerAngles == transform.localEulerAngles && bat.GetComponent<ObjectTouchMovement>().charged == true)
            {
                c.isTrigger = true;

                //sets battery to center of goal panel
                bat.transform.position = new Vector3(transform.position.x, transform.position.y, 0.1867551f);

                //stops movement of the battery
                bat.GetComponent<ObjectTouchMovement>().check.moving = false;

                //disable input ability of the battery
                bat.GetComponent<ObjectTouchMovement>().enabled = false;

                //make the battery intangible
                bat.GetComponent<Collider2D>().isTrigger = true;

                bat.tag = "Untagged";

                filled = true;

                GetComponent<SpriteRenderer>().sprite = victorySprite;
                bat.GetComponent<SpriteRenderer>().sprite = bat.GetComponent<ObjectTouchMovement>().victorySprite;
            }
        }
    }
}