using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    GameObject Menu;
    GameObject GamePlay;
    GameObject Win;

    int winCounter = 0;
    int masterCount;

    // Use this for initialization
    void Start ()
    {
        Menu = GameObject.Find("Menu Canvas");
        GamePlay = GameObject.Find("Game Canvas");
        Win = GameObject.Find("Win Canvas");
        
        Menu.SetActive(false);
        GamePlay.SetActive(true);
        Win.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		//if(GamePlay.activeInHierarchy == true)
        //{
        //    winCounter = GamePlay.GetComponentInChildren<MoveCounter>().Counter;
        //    masterCount = GamePlay.GetComponentInChildren<MoveCounter>().masterCount;
        //}
	}

    public void CountUpdate()
    {
        winCounter = GamePlay.GetComponentInChildren<MoveCounter>().Counter;
        masterCount = GamePlay.GetComponentInChildren<MoveCounter>().masterCount;
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
        Win.SetActive(false);
    }

    public void Back()
    {
        Menu.SetActive(false);
        GamePlay.SetActive(true);
        Win.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void WinScreen()
    {
        Menu.SetActive(false);
        GamePlay.SetActive(false);
        Win.SetActive(true);

        GameObject count = GameObject.Find("Count Comparison");
        count.GetComponent<UnityEngine.UI.Text>().text = winCounter.ToString() + '/' + masterCount.ToString();
    }

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(next);
    }
}
