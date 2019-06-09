using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//attach to button
//once clicked sends player to the designated level

public class ButtonLevelSelect : MonoBehaviour
{
    //public
    public Button butt;

    //other
    string text;

	// Use this for initialization
	void Start () {
        butt = gameObject.GetComponent<Button>();
        butt.onClick.AddListener(TaskOnClick);

        text = butt.GetComponentInChildren<Text>().text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        Debug.Log(text);
        SceneManager.LoadScene(text);
    }
}