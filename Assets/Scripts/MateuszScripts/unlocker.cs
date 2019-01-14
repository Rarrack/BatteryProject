using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlocker : MonoBehaviour {

    public List<wallToggle> keys;

    private Color off; //grey for deact
    private Color on; //seafoam green for on

    public bool unlock;

    // Use this for initialization
    void Start () {
        off = Color.gray;
        on = gameObject.GetComponent<SpriteRenderer>().color;
        unlock = false;
    }
	
	// Update is called once per frame
	void Update () {
		foreach (wallToggle key in keys)
        {
            if (key.trig == true)
            {
                unlock = false;
                break;
            }
            else
            {
                unlock = true;
            }
        }

        if(unlock == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = off;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = on;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
	}
}