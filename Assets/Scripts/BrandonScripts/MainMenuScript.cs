using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    GameObject title;
    GameObject stage;
    GameObject start;
    GameObject level1;
    GameObject level2;
    GameObject back;

    void Start ()
    {
        title = GameObject.Find("Title");
        stage = GameObject.Find("Stage Title");
        start = GameObject.Find("Start Button");
        level1 = GameObject.Find("Level 1");
        level2 = GameObject.Find("Level 2");
        back = GameObject.Find("Back Button");

        stage.SetActive(false);
        level1.SetActive(false);
        level2.SetActive(false);
        back.SetActive(false);
    }
	
	void Update ()
    {
		
	}

    public void StartGame()
    {
        title.SetActive(false);
        start.SetActive(false);
        stage.SetActive(true);
        level1.SetActive(true);
        level2.SetActive(true);
        back.SetActive(true);
    }

    public void BackOut()
    {
        title.SetActive(true);
        start.SetActive(true);
        stage.SetActive(false);
        level1.SetActive(false);
        level2.SetActive(false);
        back.SetActive(false);
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene("SlidingPuzzle");
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("SlidingPuzzle2");
    }


}
