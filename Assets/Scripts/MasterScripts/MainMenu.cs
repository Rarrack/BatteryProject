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

    public int currentStage; // Current stage to be displayed in pop up
    public int currentCount; // Current # of moves to be displayed in pop up
    public int levelNumber; // Current level to be displayed in pop up


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
        //GameObject.Find("__bgm").GetComponent<BGM_Manager>().musicFiles[0].source.volume = PlayerPrefs.GetFloat("BGM Volume");
        //GameObject.Find("__sfx").GetComponent<SFX_Manager>().soundFiles[0].source.volume = PlayerPrefs.GetFloat("SFX Volume");
        //GameObject.Find("__bgm").GetComponent<BGM_Manager>().PlayMusic("Temp Title");
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
                SceneManager.LoadScene(sceneToLoad);
            }
        }
	}

    public void StartGame() //brings up stage select
    {
        Main.SetActive(false);
        StageSelect.SetActive(true);
        Settings.SetActive(false);
        LevelPreview.SetActive(false);
    }

    public void SettingsSelect() //brings up settings
    {
        Main.SetActive(false);
        StageSelect.SetActive(false);
        Settings.SetActive(true);
        LevelPreview.SetActive(false);

        //sets sliders in settings to correct values when loaded in
        bgmSlider.value = PlayerPrefs.GetFloat("BGM Volume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX Volume");
    }

<<<<<<< HEAD
    public void PreviewSelect() //brings up level preview for currently selected level
=======
    public void PreviewSelect() //brings up level pop up
>>>>>>> ec527141ca64afbda59325af94bbc1c1c1d695bf
    {
        LevelPreview.SetActive(true);

        //NEW CODE=======================
        //still gotta check if it works for other levels and change dimension of the preview base img itself

        //gotta do the img change here before stageSelect gets deactivated
        GameObject tempImg = LevelPreview.transform.Find("Level Image").gameObject; //gets the Level Image child obj of LevelPreview
                                                                                    //will use this to change the LevelPreview img once starts

        GameObject selectDerive = StageSelect.transform.Find("Stage " + (currentStage + 1)).gameObject; //gets the current Stage N child obj from StageSelect (gets N from currentStage + 1)
        GameObject selectDerivePrime = selectDerive.transform.Find("Level " + levelNumber).gameObject; //gets the selected Level M child obj from Stage N (gets M from levelNumber)
        Sprite Img = selectDerivePrime.GetComponent<SceneInfo>().levelImg; //gets levelImg property from the selected Level obj and stores it into an img obj

        tempImg.GetComponent<SpriteRenderer>().sprite = Img; //sets stored level img to the preview img

        //===============================

        Main.SetActive(false);
        StageSelect.SetActive(false);

        LevelPreview.GetComponent<LevelPopUp>().CurrentStage = currentStage; // sets current stage in the LevelPopUp script
        LevelPreview.GetComponent<LevelPopUp>().CurrentLevel = levelNumber; // sets current level in the LevelPopUp script
        LevelPreview.GetComponent<LevelPopUp>().CurrentCount = currentCount; // sets # of moves in the LevelPopUp script
    }

    public void LoadLevel() //activates fade screen to load in new scene
    {
        FadeScreen.SetActive(true);
        FadeScreen.GetComponent<Animator>().Play("Anim_Fade");
        FadeStart = true;
    }

    public void BackOut() //brings up main menu
    {
        Main.SetActive(true);
        StageSelect.SetActive(false);
        Settings.SetActive(false);
        LevelPreview.SetActive(false);
    }

    public void PreviewBackOut() //brings up level select
    {
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