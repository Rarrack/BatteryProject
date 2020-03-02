using System.Collections;
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
    GameObject LevelPreview; // level preview object

    // Volume sliders
    public Slider bgmSlider;
    public Slider sfxSlider;

    int currentStage; // Current stage to be displayed in pop up
    public int CurrentStage
    {
        get
        {
            return currentStage;
        }
        set
        {
            currentStage = value;
        }
    }
    int currentCount; // Current # of moves to be displayed in pop up
    public int CurrentCount
    {
        get
        {
            return currentCount;
        }
        set
        {
            currentCount = value;
        }
    }
    int levelNumber; // Current level to be displayed in pop up
    public int LevelNumber
    {
        get
        {
            return levelNumber;
        }
        set
        {
            levelNumber = value;
        }
    }
    Sprite previewImg; // Image to be used in level preview
    public Sprite PreviewImg
    {
        get
        {
            return previewImg;
        }
        set
        {
            previewImg = value;
        }
    }


    GameObject fadeScreen; // screen to be faded
    int waitTime = 0; // how long fade lasts
    bool fadeStart = false; // determines when fade will start
    int sceneToLoad = 0; // determines which scene will load
    public GameObject FadeScreen
    {
        get
        {
            return fadeScreen;
        }
    }
    public bool FadeStart
    {
        get
        {
            return fadeStart;
        }
        set
        {
            fadeStart = value;
        }
    }
    public int SceneToLoad
    {
        get
        {
            return sceneToLoad;
        }
        set
        {
            sceneToLoad = value;
        }
    }


    void Awake()
    {
        // Sets volume of music and sounds then plays main theme
        GameObject.Find("__bgm").GetComponent<BGM_Manager>().musicFiles[0].source.volume = PlayerPrefs.GetFloat("BGM Volume");
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().soundFiles[0].source.volume = PlayerPrefs.GetFloat("SFX Volume");
        GameObject.Find("__bgm").GetComponent<BGM_Manager>().PlayMusic("Main Theme");
    }

    // Use this for initialization
    void Start ()
    {
        // Setting objects to their respective gameobjects within the inspector
        Main = GameObject.Find("Main Menu");
        StageSelect = GameObject.Find("Stage Select");
        Settings = GameObject.Find("Settings");
        LevelPreview = GameObject.Find("Level Preview");
        fadeScreen = GameObject.Find("Fade Screen");

        int x = PlayerPrefs.GetInt("Level Select"); // Sets variable that determines whether scene starts on level select screen

        // Sets volumes of bgm and sfx and has default value in case either doesn't have one
        bgmSlider.value = PlayerPrefs.GetFloat("BGM Volume", 0.7f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFX Volume", 0.7f);

        fadeScreen.SetActive(false); // Sets fade screen to false when scene loads

        // Checks to see if stage select should be active when scene is loaded in
        if (x == 0)
        {
            StageSelect.SetActive(false);
            Settings.SetActive(false);
            LevelPreview.SetActive(false);
        }
        else
        {
            Main.SetActive(false);
            Settings.SetActive(false);
            LevelPreview.SetActive(false);
            PlayerPrefs.SetInt("Level Select", 0);
            PlayerPrefs.Save();
        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        // determins if fade should start and loads level when fade completes
		if(fadeStart == true)
        {
            waitTime += 1;
            if(waitTime >= 53)
            {
                fadeStart = false;
                waitTime = 0;
                GameObject.Find("__bgm").GetComponent<BGM_Manager>().StopMusic("Main Theme");
                SceneManager.LoadScene(sceneToLoad);
            }
        }
	}

    public void StartGame() //brings up stage select
    {
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Accept");
        Main.SetActive(false);
        StageSelect.SetActive(true);
        Settings.SetActive(false);
        LevelPreview.SetActive(false);
    }

    public void SettingsSelect() //brings up settings
    {
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Accept");
        Main.SetActive(false);
        StageSelect.SetActive(false);
        Settings.SetActive(true);
        LevelPreview.SetActive(false);

        //sets sliders in settings to correct values when loaded in
        bgmSlider.value = PlayerPrefs.GetFloat("BGM Volume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX Volume");
    }

    public void PreviewSelect() //brings up level preview for currently selected level
    {
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Accept");
        LevelPreview.SetActive(true);

        LevelPreview.GetComponent<LevelPopUp>().preview.GetComponent<SpriteRenderer>().sprite = previewImg;
        LevelPreview.GetComponent<LevelPopUp>().CurrentStage = currentStage; // sets current stage in the LevelPopUp script
        LevelPreview.GetComponent<LevelPopUp>().CurrentLevel = levelNumber; // sets current level in the LevelPopUp script
        LevelPreview.GetComponent<LevelPopUp>().CurrentCount = currentCount; // sets # of moves in the LevelPopUp script
        LevelPreview.GetComponent<LevelPopUp>().CounterSet();

        Main.SetActive(false);
        StageSelect.SetActive(false);  
    }

    public void LoadLevel() //activates fade screen to load in new scene
    {
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Accept");
        FadeScreen.SetActive(true);
        FadeScreen.GetComponent<Animator>().Play("Anim_Fade");
        FadeStart = true;
    }

    public void BackOut() //brings up main menu
    {
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Back");
        Main.SetActive(true);
        StageSelect.SetActive(false);
        Settings.SetActive(false);
        LevelPreview.SetActive(false);
    }

    public void PreviewBackOut() //brings up level select
    {
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Back");
        Main.SetActive(false);
        StageSelect.SetActive(true);
        Settings.SetActive(false);
        LevelPreview.SetActive(false);
    }

    public void DataPurge() // deletes all save data
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}