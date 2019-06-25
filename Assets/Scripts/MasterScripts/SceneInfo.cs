using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInfo : MonoBehaviour
{
    UnityEngine.UI.Button button;
    public int levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        int x = PlayerPrefs.GetInt("Level " + levelNumber);
        button = GetComponent<UnityEngine.UI.Button>();
        if(x == 0)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Level " + levelNumber + " " + PlayerPrefs.GetInt("Level " + levelNumber));
        if(PlayerPrefs.GetInt("Level " + levelNumber) == 1)
        {
            button.interactable = true;
        }
    }

    public void Load()
    {
        SceneManager.LoadScene(levelNumber + 1);
    }
}
