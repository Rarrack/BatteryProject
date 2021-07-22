using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneInfo : MonoBehaviour
{
    Button button;
    MainMenu menu;
    StageSwitch switcher;
    public int levelNumber;
    public int sceneCount;
    public GameObject rating;
    public Sprite[] ratings;

    public Sprite levelImg; //the image of the level itself.
                            //each level needs its image stored in this public varibale.

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("Main Menu Canvas").GetComponent<MainMenu>();
        switcher = GameObject.Find("Stage Select").GetComponent<StageSwitch>();
        int x = PlayerPrefs.GetInt("Level " + levelNumber);
        button = GetComponent<Button>();

        if (x == 0)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }

        LevelRating();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Level " + levelNumber) == 1)
        {
            button.interactable = true;
        }
    }

    public void LevelRating()
    {
        if(PlayerPrefs.GetInt("Count " + levelNumber) == 0)
        {
            rating.SetActive(false);
        }

        if(PlayerPrefs.GetInt("Count " + levelNumber) > 0 && PlayerPrefs.GetInt("Count " + levelNumber) >= sceneCount)
        {
            rating.SetActive(true);
            rating.GetComponent<Image>().sprite = ratings[0];
        }

        if(PlayerPrefs.GetInt("Count " + levelNumber) > 0 && PlayerPrefs.GetInt("Count " + levelNumber) <= sceneCount)
        {
            rating.SetActive(true);
            rating.GetComponent<Image>().sprite = ratings[1];
        }
    }

    public void Load()
    {
        //GameObject.Find("__bgm").GetComponent<BGM_Manager>().StopMusic("Temp Title");
        menu.FadeScreen.SetActive(true);
        menu.FadeScreen.GetComponent<Animator>().Play("Anim_Fade");
        menu.SceneToLoad = levelNumber + 1;
        menu.FadeStart = true;
        //SceneManager.LoadScene(levelNumber + 1);
    }

    public void Choice()
    {
        menu.PreviewImg = levelImg;
        menu.CurrentStage = switcher.currentStage;
        menu.SceneToLoad = levelNumber + 1;
        menu.CurrentCount = sceneCount;
        menu.LevelNumber = levelNumber;
        menu.PreviewSelect();
    }
}