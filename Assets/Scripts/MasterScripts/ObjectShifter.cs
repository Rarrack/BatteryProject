using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//uses Brandon's BatteryShifter
//Should be attatched to walls and other non movable objects
//Shifts the object such that it isn't pernamently hitting another object

public class ObjectShifter : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //check if its a dummy or battery that hit the non movable object
        if (collision.gameObject.tag == "Battery" || collision.gameObject.tag == "dummy")
        {
            foreach (ContactPoint2D hitPos in collision.contacts)
            {
                if (hitPos.normal.y > 0)
                {
                    //Debug.Log("Hit the top: " + hitPos.normal.y);
                    collision.transform.localPosition -= new Vector3(0, 0.05f, 0);
                }
                if (hitPos.normal.y < 0)
                {
                    //Debug.Log("Hit the top: " + hitPos.normal.y);
                    collision.transform.localPosition += new Vector3(0, 0.05f, 0);
                }
                if (hitPos.normal.x > 0)
                {
                    //Debug.Log("Hit the top: " + hitPos.normal.y);
                    collision.transform.localPosition -= new Vector3(0.05f, 0, 0);
                }
                if (hitPos.normal.x < 0)
                {
                    //Debug.Log("Hit the top: " + hitPos.normal.y);
                    collision.transform.localPosition += new Vector3(0.05f, 0, 0);
                }
            }
        }
    }
}