using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    GameObject Menu;
    GameObject GamePlay;
    GameObject Win;

    List<GameObject> goals = new List<GameObject>();

    int winCounter = 0;
    int masterCount;
    int allFilled = 0;

    // Use this for initialization
    void Start ()
    {
        Menu = GameObject.Find("Menu Canvas");
        GamePlay = GameObject.Find("Game Canvas");
        Win = GameObject.Find("Win Canvas");

        foreach (Transform goal in GameObject.FindGameObjectWithTag("Goals").transform)
        {
            goals.Add(goal.gameObject);
        }
        
        Menu.SetActive(false);
        GamePlay.SetActive(true);
        Win.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        for(int i = 0; i < goals.Count; i++)
        {
            if (goals[i].GetComponent<GoalSettings>().Filled == true)
            {
                allFilled += 1;
            }
            if(allFilled == goals.Count)
            {
                WinScreen();
            }
        }

        allFilled = 0;
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
        PlayerPrefs.SetInt("Level Select", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt("Level Select", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void WinScreen()
    {
        Menu.SetActive(false);
        GamePlay.SetActive(false);
        Win.SetActive(true);

        PlayerPrefs.SetInt("Level " + SceneManager.GetActiveScene().buildIndex, 1);
        GameObject count = GameObject.Find("Count Comparison");
        count.GetComponent<UnityEngine.UI.Text>().text = winCounter.ToString() + '/' + masterCount.ToString();
        PlayerPrefs.SetInt("Count " + SceneManager.GetActiveScene().buildIndex, winCounter);
        PlayerPrefs.Save();
    }

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(next);
    }
}
