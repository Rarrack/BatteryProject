﻿using System.Collections;
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

    GameObject fadeScreen;
    public GameObject FadeScreen
    {
        get
        {
            return fadeScreen;
        }
    }

    int winCounter = 0;
    int masterCount;
    int allFilled = 0;
    bool win = false;
    int activateWin = 0;
    public List<Sprite> victoryTypes;

    int whereTo = 0;
    public int WhereTo
    {
        get
        {
            return whereTo;
        }
        set
        {
            whereTo = value;
        }
    }

    void Awake()
    {
        GameObject.Find("__bgm").GetComponent<BGM_Manager>().musicFiles[0].source.volume = PlayerPrefs.GetFloat("BGM Volume");
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().soundFiles[0].source.volume = PlayerPrefs.GetFloat("SFX Volume");
    }

    // Use this for initialization
    void Start ()
    {
        GameObject.Find("__bgm").GetComponent<BGM_Manager>().PlayStageMusic(SceneManager.GetActiveScene().buildIndex);
        Menu = GameObject.Find("Menu Canvas");
        GamePlay = GameObject.Find("Game Canvas");
        Win = GameObject.Find("Win Canvas");
        fadeScreen = GameObject.Find("Fader");

        bgmSlider.value = PlayerPrefs.GetFloat("BGM Volume", 0.7f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFX Volume", 0.7f);

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
            if(allFilled == goals.Count && win == false)
            {
                win = !win;
                GameObject.Find("__bgm").GetComponent<BGM_Manager>().StopStageMusic(SceneManager.GetActiveScene().buildIndex);
                GameObject.Find("__bgm").GetComponent<BGM_Manager>().PlayMusic("Victory Theme");
                //WinScreen();
            }
        }

        if(win == true && activateWin <= 120)
        {
            activateWin += 1;
        
            if(activateWin >= 120)
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
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Accept");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MenuActivate()
    {
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Accept");
        Menu.SetActive(true);
        GamePlay.SetActive(false);
        Win.SetActive(false);
        bgmSlider.value = PlayerPrefs.GetFloat("BGM Volume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX Volume");
    }

    public void Back()
    {
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Back");
        Menu.SetActive(false);
        GamePlay.SetActive(true);
        Win.SetActive(false);
    }

    public void MainMenu()
    {
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Accept");
        GameObject.Find("__bgm").GetComponent<BGM_Manager>().StopMusic("Victory Theme");
        GameObject.Find("__bgm").GetComponent<BGM_Manager>().StopStageMusic(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("Level Select", 0);
        PlayerPrefs.Save();
        FadeScreen.GetComponent<Animator>().SetBool("Leave Scene", true);
        whereTo = 1;
    }

    public void LevelSelect()
    {
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Accept");
        GameObject.Find("__bgm").GetComponent<BGM_Manager>().StopMusic("Victory Theme");
        PlayerPrefs.SetInt("Level Select", 1);
        PlayerPrefs.Save();
        FadeScreen.GetComponent<Animator>().SetBool("Leave Scene", true);
        whereTo = 1;
    }

    public void NextLevel()
    {
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Accept");
        GameObject.Find("__bgm").GetComponent<BGM_Manager>().StopMusic("Victory Theme");
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        FadeScreen.GetComponent<Animator>().SetBool("Leave Scene", true);
        whereTo = next;
    }

    public void WinScreen()
    {
        Menu.SetActive(false);
        GamePlay.SetActive(false);
        Win.SetActive(true);

        if(winCounter >= masterCount)
        {
            GameObject.Find("Win Stamp").GetComponent<SpriteRenderer>().sprite = victoryTypes[0];
        }
        else
        {
            GameObject.Find("Win Stamp").GetComponent<SpriteRenderer>().sprite = victoryTypes[1];
        }
        
        PlayerPrefs.SetInt("Level " + SceneManager.GetActiveScene().buildIndex, 1);
        GameObject count = GameObject.Find("Count Comparison");
        count.GetComponent<UnityEngine.UI.Text>().text = winCounter.ToString() + '/' + masterCount.ToString();
        if(PlayerPrefs.GetInt("Count " + (SceneManager.GetActiveScene().buildIndex - 1).ToString()) == 0 || PlayerPrefs.GetInt("Count " + (SceneManager.GetActiveScene().buildIndex - 1).ToString()) >= winCounter)
        {
            PlayerPrefs.SetInt("Count " + (SceneManager.GetActiveScene().buildIndex - 1), winCounter);
        }
        PlayerPrefs.Save();
    }

    
}
