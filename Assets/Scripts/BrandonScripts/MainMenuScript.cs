using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    GameObject MainMenu;
    GameObject StageSelect;
    GameObject Settings;

    void Start ()
    {
        MainMenu = GameObject.Find("Main Menu");
        StageSelect = GameObject.Find("Stage Select");
        Settings = GameObject.Find("Settings");

        StageSelect.SetActive(false);
        Settings.SetActive(false);
    }
	
	void Update ()
    {
		
	}

    public void StartGame()
    {
        MainMenu.SetActive(false);
        StageSelect.SetActive(true);
        Settings.SetActive(false);
    }
    public void SettingsSelect()
    {
        MainMenu.SetActive(false);
        StageSelect.SetActive(false);
        Settings.SetActive(true);
    }

    public void BackOut()
    {
        MainMenu.SetActive(true);
        StageSelect.SetActive(false);
        Settings.SetActive(false);
    }

    //public void ExitGame()
    //{
    //    Application.Quit();
    //}

    public void StartLevel1()
    {
        //SceneManager.LoadScene("SlidingPuzzle");
        SceneManager.LoadScene(0);
    }

    public void StartLevel2()
    {
        //SceneManager.LoadScene("SlidingPuzzle2");
    }


}
