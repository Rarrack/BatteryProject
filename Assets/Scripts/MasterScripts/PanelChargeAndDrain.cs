using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Mateusz's GoalSub script and Brandon's ChargePanels script
//attach this to charge/drain panels
//depending on which type the panel is set to (based on if charger is set to true or false), it will either drain or charge
//a battery that connects with it

public class PanelChargeAndDrain : MonoBehaviour {

    //public
    //public ObjectMovement script;

    //public Transform battery;

    //public Transform panel;

    public bool charger; //if set to true, panel is a charger. if false, panel is a drainer

    //other
    //Vector3 b; //vector value for the battery

    Vector3 cd; //vector value for the charge/drain panel

    Collider2D c; //collider for this object

	// Use this for initialization
	void Start () {
        cd = gameObject.transform.position;
        c = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
     * maybe replace all on collision enters with trigger enters in other scripts?
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Battery" || collision.gameObject.tag == "Battery 2")
        {
            Vector3 b = collision.transform.position;
            
            b.x = cd.x; //set position of battery to panel
            b.y = cd.y;

            collision.transform.position = b;

            //drain option
            if (charger == false)
            {
                collision.gameObject.GetComponent<ObjectMovement>().charged = false;
                /*
                 * selection logic may overwrite the grey color, find workaround. replace with textures
                 */
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            }

            //charge option
            if (charger == true)
            {
                collision.gameObject.GetComponent<ObjectMovement>().charged = true;
                /*
                 * selection logic may overwrite the charge color, find workaround
                 */
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green; //used green as charge color to not confuse with select color of yellow
            }

            ObjectMovement script = collision.transform.GetComponent<ObjectMovement>();
            script.x = 0f;
            script.y = 0f;
            script.check.moving = false;

            c.isTrigger = true;
        }
        else
        {
            c.isTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        c.isTrigger = false;
    }
}