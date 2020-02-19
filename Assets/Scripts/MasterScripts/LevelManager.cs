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
            PlayerPrefs.SetInt("Level " + 2, 1);

            PlayerPrefs.SetInt("Level Select", 0);
            PlayerPrefs.SetFloat("BGM Volume", 0.7f);
            PlayerPrefs.SetFloat("SFX Volume", 0.7f);
            PlayerPrefs.Save();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
