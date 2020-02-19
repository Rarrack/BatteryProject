using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPopUp : MonoBehaviour
{
    int currentStage;
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

    int currentLevel;
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
        }
    }

    int currentCount;
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

    public GameObject stageBackground;
    public Sprite[] backgrounds;

    public GameObject counterText;
    

    // Start is called before the first frame update
    void Start()
    {
        stageBackground.GetComponent<SpriteRenderer>().sprite = backgrounds[currentStage];
        counterText.GetComponent<UnityEngine.UI.Text>().text = "Least Moves: " + PlayerPrefs.GetInt("Count " + currentLevel) + "/" + currentCount;
    }

    // Update is called once per frame
    void Update()
    {
        stageBackground.GetComponent<SpriteRenderer>().sprite = backgrounds[currentStage];
        counterText.GetComponent<UnityEngine.UI.Text>().text = "Least Moves: " + PlayerPrefs.GetInt("Count " + currentLevel) + "/" + currentCount;
    }
}