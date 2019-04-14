using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCounter : MonoBehaviour
{
    int counter = 0;
    bool write = false;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(write == true)
        {
            SetCounter();
            write = false;
        }
	}

    void SetCounter()
    {
        GetComponentInChildren<UnityEngine.UI.Text>().text = "Moves: " + counter;
    }

    public int Counter
    {
        get
        {
            return counter;
        }
        set
        {
            counter = value;
        }
    }

    public bool Write
    {
        get
        {
            return write;
        }
        set
        {
            write = value;
        }
    }
}
