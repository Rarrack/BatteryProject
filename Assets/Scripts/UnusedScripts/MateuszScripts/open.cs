using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour {

    public subGoal script;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(script.activate == true)
        {
            gameObject.SetActive(false);
        }
	}
}