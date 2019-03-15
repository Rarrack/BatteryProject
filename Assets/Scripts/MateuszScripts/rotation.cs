using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

    public moveInput script;

    public Transform battery;
    public Transform panel;

    Vector3 b;
    Vector3 p;

    Collider2D c;

	// Use this for initialization
	void Start () {
        b = battery.position;
        p = panel.position;

        c = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Battery")
        {
            b.x = p.x;
            b.y = p.y;

            battery.position = b;

            if(battery.eulerAngles.z == 0)
            {
                battery.eulerAngles = new Vector3(0, 0, 90);
            }
            else if(battery.eulerAngles.z == 90)
            {
                battery.eulerAngles = new Vector3(0, 0, 0);
            }


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