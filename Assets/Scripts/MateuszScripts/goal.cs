using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour {

    public moveInput script;
    public Transform battery;

    public Transform end;

    Vector3 b;
    Vector3 e;

	// Use this for initialization
	void Start () {
        b = battery.position;
        e = end.position;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Battery" && battery.rotation == end.rotation)
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
            collision.gameObject.GetComponent<moveInput>().x = 0f;
            collision.gameObject.GetComponent<moveInput>().y = 0f;
            collision.gameObject.GetComponent<moveInput>().moving = false;
        }
    }
}