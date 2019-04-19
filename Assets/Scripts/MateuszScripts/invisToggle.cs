using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisToggle : MonoBehaviour {

    public List<GameObject> subjects;
    public subGoal script;

    //prevents the update code from running forever
    public bool done;

    // Use this for initialization
    void Start () {
        done = false;

        foreach (GameObject subject in subjects)
        {
            //potentially refactor the inside into another method, so that containers can be put in containers
            if (subject.GetComponent<SpriteRenderer>() == null) //this is for containers that hold alot of children, do not nest another container in it
            {
                Transform parent = subject.transform;
                foreach (Transform child in parent)
                {
                    child.GetComponent<SpriteRenderer>().enabled = false;
                    if(child.GetComponent<moveInput>() != null) //checks if it has a moveInput script
                    {
                        child.GetComponent<moveInput>().enabled = false;
                    }
                }
            }
            else //this is for individual objects
            {
                subject.GetComponent<SpriteRenderer>().enabled = false;
                if (subject.GetComponent<moveInput>() != null) //checks if it has a moveInput script
                {
                    subject.GetComponent<moveInput>().enabled = false;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (script.activate == true && done == false)
        {
            foreach (GameObject subject in subjects)
            {
                if (subject.GetComponent<SpriteRenderer>() == null)
                {
                    Transform parent = subject.transform;
                    foreach (Transform child in parent)
                    {
                        child.GetComponent<SpriteRenderer>().enabled = true;
                        if (child.GetComponent<moveInput>() != null)
                        {
                            child.GetComponent<moveInput>().enabled = true;
                        }
                    }
                }
                else
                {
                    subject.GetComponent<SpriteRenderer>().enabled = true;
                    if (subject.GetComponent<moveInput>() != null)
                    {
                        subject.GetComponent<moveInput>().enabled = true;
                    }
                }
            }

            done = true;
        }
    }
}