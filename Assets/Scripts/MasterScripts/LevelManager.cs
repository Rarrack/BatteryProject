using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelManager : MonoBehaviour
{
    // Sets up all information that will be saved and persistant through the game
    private void Awake()
    {
        // Check to see data is already present
        if (!PlayerPrefs.HasKey("Level Select"))
        {
            List<string> scenes = new List<string>(); // Holds all scenes in the game
            for (int i = 2; i < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
            {
                scenes.Add(UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(i).ToString()); // Adds in all levels to holder
            }

            // Creates information to hold each level, if it's unlocked and the # of moves used in that level
            for (int i = 0; i < scenes.Count; i++)
            {
                PlayerPrefs.SetInt("Level " + (i + 1), 0);
                PlayerPrefs.SetInt("Count " + (i + 1), 1);
            }            
            PlayerPrefs.SetInt("Level " + 1, 1); // Sets first level to be active by default 

            PlayerPrefs.SetInt("Level Select", 0); // Check to see if level select is active

            // Volume Checks
            PlayerPrefs.SetFloat("BGM Volume", 0.7f);
            PlayerPrefs.SetFloat("SFX Volume", 0.7f);

            PlayerPrefs.Save(); // Saves all PlayerPref information
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1); // Loads in Main Menu after all data is set up
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
