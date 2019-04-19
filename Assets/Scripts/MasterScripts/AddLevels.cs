using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

//adds the levels that were put into the list to the scrollable menu

public class AddLevels : MonoBehaviour
{
    //public
    public List<string> scenes; //list of scenes, have to choose the size and then type in the name

    public GameObject buttonTemplate; //the base template for the level buttons

    public Transform newParent; //object to add the generated buttons to

	// Use this for initialization
	void Start () {
		foreach(string scene in scenes)
        {
            //create new button instance based off of template
            GameObject dummy = Instantiate(buttonTemplate);

            //names it after the scene it links to
            dummy.GetComponentInChildren<Text>().text = scene;

            //add it to the grid of elements list
            dummy.transform.SetParent(newParent);
        }

        Destroy(buttonTemplate); //get rid of the button afterwards since it'll be an unused leftover
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
