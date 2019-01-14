using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallToggle : MonoBehaviour {

    private Color off; //grey for deact
    private Color on; //seafoam green for on, both correspondings should have the same colors

    SpriteRenderer s; //color of switch

    public GameObject battCorrespond;//object for switches activated by batteries
    public GameObject dummCorrespond;//object for switches activated by dummies 

    public bool trig; //all purpose bool, used for checking if objects are active at first and set colors accordingly

	// Use this for initialization
	void Start () {
        trig = false; //set just so it has a value to work off of
        off = Color.gray;

        s = gameObject.GetComponent<SpriteRenderer>();
        s.color = new Color(1f, 0.6f, 0f);

        //if either one is unused, set to empty object. never have either unused, always should have at least one active
        if (battCorrespond == null)
        {
            battCorrespond = new GameObject();
            battCorrespond.tag = "placebo";
            s.color = new Color(0.5f, 0f, 0f);

            trig = dummCorrespond.GetComponent<BoxCollider2D>().isTrigger;
            on = dummCorrespond.GetComponent<SpriteRenderer>().color;
            if(trig == true)
            {
                dummCorrespond.GetComponent<SpriteRenderer>().color = off;
            }
            else
            {
                dummCorrespond.GetComponent<SpriteRenderer>().color = on;
            }
        }
        else if (dummCorrespond == null)
        {
            dummCorrespond = new GameObject();
            dummCorrespond.tag = "placebo";
            s.color = Color.yellow;

            trig = battCorrespond.GetComponent<BoxCollider2D>().isTrigger;
            on = battCorrespond.GetComponent<SpriteRenderer>().color;
            if (trig == true)
            {
                battCorrespond.GetComponent<SpriteRenderer>().color = off;
            }
            else
            {
                battCorrespond.GetComponent<SpriteRenderer>().color = on;
            }
        }
        else
        {
            on = battCorrespond.GetComponent<SpriteRenderer>().color;

            trig = dummCorrespond.GetComponent<BoxCollider2D>().isTrigger;
            if (trig == true)
            {
                dummCorrespond.GetComponent<SpriteRenderer>().color = off;
            }
            else
            {
                dummCorrespond.GetComponent<SpriteRenderer>().color = on;
            }

            trig = battCorrespond.GetComponent<BoxCollider2D>().isTrigger;
            if (trig == true)
            {
                battCorrespond.GetComponent<SpriteRenderer>().color = off;
            }
            else
            {
                battCorrespond.GetComponent<SpriteRenderer>().color = on;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Battery" && battCorrespond.tag != "placebo")
        {
            trig = battCorrespond.GetComponent<BoxCollider2D>().isTrigger;

            if (trig == false)
            {
                battCorrespond.GetComponent<BoxCollider2D>().isTrigger = true;
                battCorrespond.GetComponent<SpriteRenderer>().color = off;
            }
            else
            {
                battCorrespond.GetComponent<BoxCollider2D>().isTrigger = false;
                battCorrespond.GetComponent<SpriteRenderer>().color = on;
            }
        }

        if(collision.gameObject.tag == "dummy" && dummCorrespond.tag != "placebo")
        {
            trig = dummCorrespond.GetComponent<BoxCollider2D>().isTrigger;

            if (trig == false)
            {
                dummCorrespond.GetComponent<BoxCollider2D>().isTrigger = true;
                dummCorrespond.GetComponent<SpriteRenderer>().color = off;
            }
            else
            {
                dummCorrespond.GetComponent<BoxCollider2D>().isTrigger = false;
                dummCorrespond.GetComponent<SpriteRenderer>().color = on;
            }
        }
    }
}