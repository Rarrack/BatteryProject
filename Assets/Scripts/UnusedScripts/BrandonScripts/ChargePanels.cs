using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePanels : MonoBehaviour
{

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
        if(col.gameObject.tag == "Battery" && gameObject.name == "Drain Panel")
        {
            col.gameObject.GetComponent<BatteryBehavior>().Charged = false;
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        if (col.gameObject.tag == "Battery" && gameObject.name == "Charge Panel")
        {
            col.gameObject.GetComponent<BatteryBehavior>().Charged = true;
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}
