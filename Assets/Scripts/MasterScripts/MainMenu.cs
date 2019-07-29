﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Based off of Brandon's MainMenuScript
//Sets up the main menu

public class MainMenu : MonoBehaviour
{
    //other
    GameObject Main; //main menu object

    GameObject StageSelect; //stage select object

    GameObject Settings; //settings object

    public Slider bgmSlider;
    public Slider sfxSlider;

    void Awake()
    {
        GameObject.Find("__bgm").GetComponent<BGM_Manager>().musicFiles[0].source.volume = PlayerPrefs.GetFloat("BGM Volume");
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().soundFiles[0].source.volume = PlayerPrefs.GetFloat("SFX Volume");
        GameObject.Find("__bgm").GetComponent<BGM_Manager>().PlayMusic("Temp Title");
    }

    // Use this for initialization
    void Start ()
    {
        Main = GameObject.Find("Main Menu");
        StageSelect = GameObject.Find("Stage Select");
        Settings = GameObject.Find("Settings");

        int x = PlayerPrefs.GetInt("Level Select");

        bgmSlider.value = PlayerPrefs.GetFloat("BGM Volume", 0.7f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFX Volume", 0.7f);

        if (x == 0)
        {
            StageSelect.SetActive(false);
            Settings.SetActive(false);
        }
        else
        {
            Main.SetActive(false);
            Settings.SetActive(false);
            PlayerPrefs.SetInt("Level Select", 0);
            PlayerPrefs.Save();
        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
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
        bgmSlider.value = PlayerPrefs.GetFloat("BGM Volume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX Volume");
    }

    public void BackOut() //brings up main menu
    {
        Main.SetActive(true);
        StageSelect.SetActive(false);
        Settings.SetActive(false);
    }

    public void DataPurge()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}