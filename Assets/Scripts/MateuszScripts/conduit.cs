using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conduit : MonoBehaviour {

    public bool source;
    public bool charged; //checks if contains charge
    SpriteRenderer s; //circuit's
    private Color off; //original color

	// Use this for initialization
	void Start () {
        s = gameObject.GetComponent<SpriteRenderer>();
        off = s.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(source == true)
        {
            charged = true;
        }
        
        if(collision.tag == "circuit" && source == false)
        {
            if (collision.GetComponent<conduit>().charged == true)
            {
                charged = true;
                s.color = collision.GetComponent<SpriteRenderer>().color;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        charged = false;
        s.color = off;
    }
}