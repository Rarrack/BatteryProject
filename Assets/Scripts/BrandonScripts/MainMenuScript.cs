using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    GameObject MainMenu;
    GameObject StageSelect;

    void Start ()
    {
        MainMenu = GameObject.Find("Main Menu");
        StageSelect = GameObject.Find("Stage Select");

        StageSelect.SetActive(false);
    }
	
	void Update ()
    {
		
	}

    public void StartGame()
    {
        MainMenu.SetActive(false);
        StageSelect.SetActive(true);
    }

    public void BackOut()
    {
        MainMenu.SetActive(true);
        StageSelect.SetActive(false);
    }

    public void StartLevel1()
    {
        //SceneManager.LoadScene("SlidingPuzzle");
    }

    public void StartLevel2()
    {
        //SceneManager.LoadScene("SlidingPuzzle2");
    }


}
