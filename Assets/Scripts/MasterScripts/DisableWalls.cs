using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWalls : MonoBehaviour
{
    //Brandon's MoveWalls
    //Activates designated walls disable functions
    //disables walls to be moved over when activated

    #region Wall Disable Variables/Containers

    bool activate = false;
    public GameObject battery;
    public List<GameObject> walls;

    #endregion

    void Start()
    {
    }

    public bool Activate
    {
        get
        {
            return activate;
        }
        set
        {
            activate = value;
        }
    }

    void Update()
    {
        // Tells all walls to move if the List is not empty
        if (activate == true && walls != null)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                if (walls[i].GetComponent<WallDisable>().disabled == false)
                {
                    walls[i].GetComponent<WallDisable>().Disable();
                }
                else
                {
                    walls[i].GetComponent<WallDisable>().Enable();
                }
            }

            activate = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == battery)
        {
            activate = true;
        }
    }
}
