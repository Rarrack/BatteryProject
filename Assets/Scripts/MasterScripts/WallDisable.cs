using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDisable : MonoBehaviour
{
    public bool disabled;

    // Start is called before the first frame update
    void Start()
    {
        if(disabled == false)
        {
            Enable();
        }
        else
        {
            Disable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disable()
    {
        Color curCol = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(curCol.r, curCol.g, curCol.b, 0.5f);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Enable()
    {
        Color curCol = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(curCol.r, curCol.g, curCol.b, 255);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
