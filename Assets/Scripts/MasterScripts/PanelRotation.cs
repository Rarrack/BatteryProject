using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Mateusz's rotation script and PanelChargeAndDrain script
//attach this to rotation panels
//only rotates battery objects 90 degrees

public class PanelRotation : MonoBehaviour {

    //other
    Vector3 r; //vector value for the rotation panel

    Collider2D c; //collider for this object

	// Use this for initialization
	void Start () {
        r = gameObject.transform.position;
        c = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Battery" || collision.gameObject.tag == "Battery 2")
        {
            Transform battery = collision.transform; //store the battery transform in local var
            Vector3 b = battery.position;

            b.x = r.x; //set position of battery to panel
            b.y = r.y;

            battery.position = b;

            if(battery.eulerAngles.z == 0) //if at 0 degrees, set to 90
            {
                battery.eulerAngles = new Vector3(0, 0, 90);
            }
            else if (battery.eulerAngles.z == 90) //if at 90 degrees, set to 0
            {
                battery.eulerAngles = new Vector3(0, 0, 0);
            }

            ObjectMovement script = battery.GetComponent<ObjectMovement>();
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

/*
 * redo all other scripts of this format in this finalized style?
 */