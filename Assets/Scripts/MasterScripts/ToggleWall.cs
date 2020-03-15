using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWall : MonoBehaviour
{
    //Based off of Mateusz's WallAndGateToggler script
    //allows special walls to be disabled by hitting a switch
    //can be configured to start the walls off either enabled or enabled
    //can be configured to be activated with either batteries, dummies, or both
    //can potentially have two different walls to govern if put a different wall in each slot

    public List<Sprite> types;
    public bool battery;
    public bool dummy;
    public bool pressed;
    
    int buttonType = 3;

    // Start is called before the first frame update
    void Start()
    {
        switch(ActiveCollidables())
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = types[0];
                if(pressed == false)
                {
                    GetComponent<SpriteRenderer>().color = Color.gray;
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                }
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = types[1];
                if (pressed == false)
                {
                    GetComponent<SpriteRenderer>().color = Color.gray;
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                }
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = types[2];
                if (pressed == false)
                {
                    GetComponent<SpriteRenderer>().color = Color.gray;
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                }
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(battery == true && collision.gameObject.tag == "Battery")
        {
            Toggle();
            GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Toggle Button");
        }

        if(dummy == true && collision.gameObject.tag == "dummy")
        {
            Toggle();
            GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Toggle Button");
        }
    }

    int ActiveCollidables()
    {
        if(battery == true && dummy == false)
        {
            buttonType = 0;
        }
        if(battery == false && dummy == true)
        {
            buttonType = 1;
        }
        if(battery == true && dummy == true)
        {
            buttonType = 2;
        }

        return buttonType;
    }

    void Toggle()
    {
        pressed = !pressed;

        if(pressed == false)
        {
            switch(buttonType)
            {
                case 0:
                    GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
                    break;
                case 1:
                    GetComponent<SpriteRenderer>().color = new Color(1, 0.92f, 0.016f, 0.5f);
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().color = new Color(0, 1, 1, 0.5f);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (buttonType)
            {
                case 0:
                    GetComponent<SpriteRenderer>().color = Color.red;
                    break;
                case 1:
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().color = Color.cyan;
                    break;
                default:
                    break;
            }
        }

    }
}
