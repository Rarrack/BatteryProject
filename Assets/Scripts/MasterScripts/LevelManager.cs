using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelManager : MonoBehaviour
{

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Level Select"))
        {
            List<string> scenes = new List<string>();
            for (int i = 2; i < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
            {
                scenes.Add(UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(i).ToString());
            }

            for (int i = 0; i < scenes.Count; i++)
            {
                PlayerPrefs.SetInt("Level " + (i + 1), 0);
                PlayerPrefs.SetInt("Count " + (i + 1), 0);
            }
            PlayerPrefs.SetInt("Level " + 1, 1);

            PlayerPrefs.SetInt("Level Select", 0);
            PlayerPrefs.Save();
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
