using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalls : MonoBehaviour
{
    private bool activate = false;
    
    private bool setup = false;

    public List<GameObject> walls;

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
        if (GameObject.Find("Moveable Walls") != null && setup != true)
        {
            for(int i = 0; i < GameObject.Find("Moveable Walls").transform.childCount; i++)
            {
                walls.Add(GameObject.Find("Moveable Walls").transform.GetChild(i).gameObject);
            }

            if(walls != null)
            {
                setup = true;
            }
        }

        if (activate == true)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].GetComponent<Movement>().Move();
            }

            activate = false;
        }
	}
}
