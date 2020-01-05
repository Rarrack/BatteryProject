using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    GameObject Menu;
    GameObject GamePlay;
    GameObject Win;

    public Slider bgmSlider;
    public Slider sfxSlider;

    List<GameObject> goals = new List<GameObject>();

    int winCounter = 0;
    int masterCount;
    int allFilled = 0;

    void Awake()
    {
        //GameObject.Find("__bgm").GetComponent<BGM_Manager>().musicFiles[0].source.volume = PlayerPrefs.GetFloat("BGM Volume");
        //GameObject.Find("__sfx").GetComponent<SFX_Manager>().soundFiles[0].source.volume = PlayerPrefs.GetFloat("SFX Volume");
    }

    // Use this for initialization
    void Start ()
    {
        Menu = GameObject.Find("Menu Canvas");
        GamePlay = GameObject.Find("Game Canvas");
        Win = GameObject.Find("Win Canvas");

        //bgmSlider.value = PlayerPrefs.GetFloat("BGM Volume", 0.7f);
        //sfxSlider.value = PlayerPrefs.GetFloat("SFX Volume", 0.7f);

        //foreach (Transform goal in GameObject.FindGameObjectWithTag("Goals").transform)
        //{
        //    goals.Add(goal.gameObject);
        //}
        GameObject[] goal;
        goal = GameObject.FindGameObjectsWithTag("Goals");

        foreach(GameObject gl in goal)
        {
            goals.Add(gl);
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
        bgmSlider.value = PlayerPrefs.GetFloat("BGM Volume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX Volume");
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
        PlayerPrefs.SetInt("Count " + (SceneManager.GetActiveScene().buildIndex - 1), winCounter);
        PlayerPrefs.Save();
    }

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(next);
    }
}
