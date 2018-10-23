using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    bool isSet = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Battery" && isSet == false)
        {
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            col.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0.1f);
            col.gameObject.transform.Rotate(0, 0, 180);
            isSet = true;
            col.gameObject.GetComponent<BatteryBehavior>().HasMoved = false;
            col.gameObject.GetComponent<BatteryBehavior>().selected = false;
            col.gameObject.GetComponent<BatteryBehavior>().ResetDirection();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        isSet = false;
    }
}
