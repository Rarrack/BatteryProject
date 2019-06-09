using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of Mateusz's GoalSub script and Brandon's ChargePanels script
//attach this to charge/drain panels
//depending on which type the panel is set to (based on if charger is set to true or false), it will either drain or charge
//a battery that connects with it

public class ChargeAndGround : MonoBehaviour
{
    public bool charger; //if set to true, panel is a charger. if false, panel is a drainer
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
            collision.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0.1867551f);

            collision.gameObject.GetComponent<ObjectTouchMovement>().check.moving = false;

            switch (charger)
            {
                case false:
                    collision.gameObject.GetComponent<ObjectTouchMovement>().charged = false;
                    collision.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
                    break;
                case true:
                    collision.gameObject.GetComponent<ObjectTouchMovement>().charged = true;
                    collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
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
