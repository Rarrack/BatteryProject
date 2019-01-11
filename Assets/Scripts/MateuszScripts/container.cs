using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class container : MonoBehaviour {
    public List<GameObject> swivels;
    public int index;
    public GameObject current;

    //private Color og; //original color
    private Color selected; //selected color

    private SpriteRenderer r;

    // Use this for initialization
    void Start () {
        index = 0;
        current = swivels[index];
        selected = Color.yellow;

        r = current.transform.Find("base").GetComponent<SpriteRenderer>();

        //og = r.color;
        r.color = selected;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //add in snap to for battery, and switch which swivel is selected
}
