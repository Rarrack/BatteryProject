using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    int x = 0;

    // Use this for initialization
    void Start ()
    {
        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                x = 1;
                break;
            default:
                x = 2;
                break;
        }

    }
	
    public void LoadLevel()
    {
        switch (x)
        {
            case 1:
                GameObject.Find("__bgm").GetComponent<BGM_Manager>().StopMusic("Main Theme");
                SceneManager.LoadScene(GameObject.Find("Main Menu Canvas").GetComponent<MainMenu>().SceneToLoad);
                break;
            case 2:
                SceneManager.LoadScene(GameObject.Find("Main Camera").GetComponent<InGameMenu>().WhereTo);
                break;
        }
    }

	
}
