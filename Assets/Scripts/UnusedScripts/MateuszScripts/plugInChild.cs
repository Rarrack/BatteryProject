using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plugInChild : MonoBehaviour {

    //check if plugged in and unoccupied
    public bool plugged;

    //snap plug to outlet vars
    public Transform outlet;

    Vector3 p;
    Vector3 o;

    // Use this for initialization
    void Start () {
        plugged = false;

        p = Vector3.zero;
        o = outlet.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "plug" && plugged == false)
        {
            plugged = true;
            transform.parent.GetComponent<multiOutlets>().TriggerDetected(this);

            p.x = o.x;
            p.y = o.y;

            collision.transform.position = p;

            moveInput script = collision.GetComponent<moveInput>();

            script.x = 0f;
            script.y = 0f;
            script.check.moving = false;

            collision.GetComponent<Rigidbody2D>().simulated = false;
        }
    }
}