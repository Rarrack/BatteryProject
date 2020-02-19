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
            for (int i = 2; i < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
            {
            }

            for (int i = 0; i < scenes.Count; i++)
            {
                PlayerPrefs.SetInt("Level " + (i + 1), 0);
                PlayerPrefs.SetInt("Count " + (i + 1), 0);
            }
            PlayerPrefs.SetInt("Level " + 1, 1);
            PlayerPrefs.SetInt("Level " + 2, 1);

            PlayerPrefs.SetFloat("BGM Volume", 0.7f);
            PlayerPrefs.SetFloat("SFX Volume", 0.7f);
        }

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
