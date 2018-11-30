using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentalRights : MonoBehaviour {

    public GameObject parent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.SetParent(parent.transform, true);
    }
}
