using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryShifter : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Battery")
        {
            foreach (ContactPoint2D hitPos in collision.contacts)
            {
                if (hitPos.normal.y > 0)
                {
                    //Debug.Log("Hit the Top: " + hitPos.normal.y);
                    collision.transform.localPosition -= new Vector3(0, 0.03f, 0);
                }
                if (hitPos.normal.y < 0)
                {
                    //Debug.Log("Hit the Bottom: " + hitPos.normal.y);
                    collision.transform.localPosition += new Vector3(0, 0.03f, 0);
                }
                if (hitPos.normal.x > 0)
                {
                    //Debug.Log("Hit the Right: " + hitPos.normal.x);
                    collision.transform.localPosition -= new Vector3(0.03f, 0, 0);
                }
                if (hitPos.normal.x < 0)
                {
                    //Debug.Log("Hit the Left: " + hitPos.normal.x);
                    collision.transform.localPosition += new Vector3(0.03f, 0, 0);
                }
            }
        }
    }

}