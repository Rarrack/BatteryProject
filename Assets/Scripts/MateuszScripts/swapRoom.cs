using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapRoom : MonoBehaviour {

    //room vars
    public List<GameObject> rooms;

    public int previ;
    public int newi;

    Vector3 posOG;
    Vector3 posDest;

    //snap battery to switch vars
    public moveInput script;

    public Transform battery;
    public Transform swap;

    Vector3 b;
    Vector3 s;

    Collider2D c;

    // Use this for initialization
    void Start () {
        previ = rooms.Count-1;
        newi = 0;

        posOG = rooms[newi].transform.position;
        posDest = new Vector3(-18.5f, -7f, -0.05664063f);
        rooms[newi].transform.position = posDest;

        b = battery.position;
        s = swap.position;

        c = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Battery")
        {
            b.x = s.x;
            b.y = s.y;

            battery.position = b;

            script.x = 0f;
            script.y = 0f;
            script.check.moving = false;

            c.isTrigger = true;

            previ = newi;
            newi++;

            if (newi > rooms.Count - 1)
            {
                newi = 0;
            }

            rooms[previ].transform.position = posOG;
            posOG = rooms[newi].transform.position;
            rooms[newi].transform.position = posDest;
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