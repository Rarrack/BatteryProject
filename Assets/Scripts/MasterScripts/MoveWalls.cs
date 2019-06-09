using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalls : MonoBehaviour
{
    //Brandon's MoveWall
    //Activates designated walls Move functions
    //shifts walls to new positions when activated

    #region Wall Movement Variables/Containers

    bool activate = false;
    public GameObject battery;
    public List<GameObject> walls;

    #endregion

    void Start ()
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

    void Update ()
    {
        // Tells all walls to move if the List is not empty
        if (activate == true && walls != null)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].GetComponent<WallMove>().Move();
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
