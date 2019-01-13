using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour {

    public moveInput script;
    public Transform battery;
    public string batteryTag;

    public Transform end;

    Vector3 b;
    Vector3 e;

    Collider2D c;

    // Use this for initialization
    void Start () {
        b = battery.position;
        e = end.position;
        c = GetComponent<Collider2D>();
        batteryTag = battery.tag;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == batteryTag && battery.rotation == end.rotation)
        {
            collision.gameObject.GetComponent<moveInput>().enabled = false;
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;

            b.x = e.x;
            b.y = e.y;

            battery.position = b;

            script.x = 0f;
            script.y = 0f;
            script.moving = false;
        }
        else
        {
            c.isTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        c.isTrigger = false;
    }
}