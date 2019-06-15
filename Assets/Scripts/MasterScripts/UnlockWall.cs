using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWall : MonoBehaviour
{
    //Based off of Mateusz's unlocker script
    //attach to a wall object, and put in the switches in the array that it will be looking at to activate
    //currently all trigs of the scripts that it looks at have to be set to false

    public List<ToggleWall> keys;

    public bool unlocked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach(ToggleWall key in keys)
        {
            if(key.pressed == true)
            {
                i += 1;
            }
        }
        if(i == keys.Count)
        {
            Unlock();
        }
        else
        {
            Lock();
        }
    }

    void Unlock()
    {
        Color curCol = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(curCol.r, curCol.g, curCol.b, 0.5f);
        GetComponent<BoxCollider2D>().enabled = false;
        unlocked = true;
    }

    void Lock()
    {
        Color curCol = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(curCol.r, curCol.g, curCol.b, 1);
        GetComponent<BoxCollider2D>().enabled = true;
        unlocked = false;
    }
}
