using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    GameObject Menu;
    GameObject GamePlay;

    // Use this for initialization
    void Start ()
    {
        Menu = GameObject.Find("Menu Canvas");
        GamePlay = GameObject.Find("Game Canvas");
        
        Menu.SetActive(false);
        GamePlay.SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MenuActivate()
    {
        Menu.SetActive(true);
        GamePlay.SetActive(false);
    }

    public void Back()
    {
        Menu.SetActive(false);
        GamePlay.SetActive(true);
    }

    public void MainMenu()
    {
        Scene scene = SceneManager.GetSceneByBuildIndex(0);
        SceneManager.LoadScene(scene.name);
    }
}
