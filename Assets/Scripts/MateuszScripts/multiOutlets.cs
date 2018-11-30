using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiOutlets : MonoBehaviour {

    public List<GameObject> outlets;
    public List<GameObject> pieces;
    public bool deact;

    // Use this for initialization
    void Start () {
        deact = false;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void TriggerDetected(plugInChild script)
    {
        //check every child, if one false then sequence is broken and cannot deactivate wall
        foreach (GameObject outlet in outlets)
        {
            if (outlet.GetComponent<plugInChild>().plugged == false)
            {
                deact = false;
                break;
            }
            else
            {
                deact = true;
            }
        }

        if (deact == true)
        {
            foreach (GameObject piece in pieces)
            {
                piece.GetComponent<BoxCollider2D>().isTrigger = true;
                piece.GetComponent<SpriteRenderer>().color = Color.gray;
            }
        }
        //Debug.Log("child collided");
    }
}