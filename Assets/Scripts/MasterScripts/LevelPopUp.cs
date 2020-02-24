using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPopUp : MonoBehaviour
{
    // Current stage that will be displayed
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

    // Currentl level that will be displayed
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

    // Count of the current level being displayed
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

    public GameObject stageBackground; // Background that will be switched out depending on stage
    public Sprite[] backgrounds; // Array holding all backgrounds for stages

    public GameObject preview;

    public GameObject counterText; // Object holding text that will display # of moves on level

    int moves;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CounterSet()
    {
        stageBackground.GetComponent<SpriteRenderer>().sprite = backgrounds[currentStage]; // Changes background depending on selected stage
        counterText.GetComponent<UnityEngine.UI.Text>().text = "Least Moves: " + PlayerPrefs.GetInt("Count " + currentLevel) + "/" + currentCount; // Changes text to display # of moves used in level
    }
}