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

    public List<Sprite> types;

    // Use this for initialization
    void Start()
    {
        c = GetComponent<Collider2D>();
        if(charger == true)
        {
            GetComponent<SpriteRenderer>().sprite = types[0];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = types[1];
        }
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
                    GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Ground");
                    collision.gameObject.GetComponent<ObjectTouchMovement>().charged = false;
                    collision.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
                    break;
                case true:
                    collision.gameObject.GetComponent<Animator>().SetBool("Charging", true);
                    GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Charge");
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
