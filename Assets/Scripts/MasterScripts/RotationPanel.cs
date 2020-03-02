using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Mateusz's rotation, PanelChargeAndDrain scripts with modifications by Brandon
//attach this to rotation panels
//only rotates battery objects 90 degrees

public class RotationPanel : MonoBehaviour
{

    Collider2D c; //collider for this object

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

        if (collision.gameObject.tag == "Battery")
        {
            GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Rotate");

            collision.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0.1867551f);

            collision.gameObject.GetComponent<ObjectTouchMovement>().check.moving = false;

            

            switch (collision.transform.localEulerAngles.z)
            {
                case 0:
                    collision.transform.localEulerAngles = new Vector3(0, 0, 90);
                    break;
                case 90:
                    collision.transform.localEulerAngles = new Vector3(0, 0, 0);
                    break;
            }
        }

        c.isTrigger = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        c.isTrigger = false;
    }
}
