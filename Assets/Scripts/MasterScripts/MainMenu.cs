using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Based off of Brandon's MainMenuScript
//Sets up the main menu

public class MainMenu : MonoBehaviour {

    //other
    GameObject Main; //main menu object

    GameObject StageSelect; //stage select object

    GameObject Settings; //settings object

	// Use this for initialization
	void Start () {
        Main = GameObject.Find("Main Menu");
        StageSelect = GameObject.Find("Stage Select");
        Settings = GameObject.Find("Settings");

        StageSelect.SetActive(false);
        Settings.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //these functions enable and disable the objects depending on what is selected
    public void StartGame() //brings up stage select
    {
        Main.SetActive(false);
        StageSelect.SetActive(true);
        Settings.SetActive(false);
    }

    public void SettingsSelect() //brings up settings
    {
        Main.SetActive(false);
        StageSelect.SetActive(false);
        Settings.SetActive(true);
    }

    public void BackOut() //brings up main menu
    {
        Main.SetActive(true);
        StageSelect.SetActive(false);
        Settings.SetActive(false);
    }

    /*
     public void ExitGame()
     {
        Application.Quit();
     }
    */

    public void StartLevel1() //loads the stored level
    {
        SceneManager.LoadScene(1);
    }

    public void StartLevel2()
    {

    }
}