using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisToggle : MonoBehaviour {

    public List<GameObject> subjects;
    public subGoal script;

    // Use this for initialization
    void Start () {
        foreach (GameObject subject in subjects)
        {
            subject.GetComponent<SpriteRenderer>().enabled = false;
            subject.GetComponent<moveInput>().enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (script.activate == true)
        {
            foreach (GameObject subject in subjects)
            {
                subject.GetComponent<SpriteRenderer>().enabled = true;
                subject.GetComponent<moveInput>().enabled = true;
            }
        }
    }
}
