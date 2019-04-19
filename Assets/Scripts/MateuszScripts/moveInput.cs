using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveInput : MonoBehaviour {

    //still have to find a way to make sure you can only move one object at a time, as well as getting rid of the collision issue

    private Color og; //original color

    private SpriteRenderer r;

    public bool over;
    public bool select;
    public bool moving;

    public float x;
    public float y;

    void Start () {
        r = GetComponent<SpriteRenderer>();

        og = r.color;

        over = false;
        select = false;
        moving = false;

        x = 0f;
        y = 0f;
	}
	
	void Update () {
        transform.Translate(x * Time.deltaTime, y * Time.deltaTime, 0f, Space.World);
    }

    void OnMouseOver()
    {
        if (moving == false)
        {
            r.color = Color.cyan;
            over = true;

            if (Input.GetMouseButton(0) && over == true)
            {
                r.color = Color.yellow;
                select = true;
            }

            if (Input.GetKey("right") && select == true)
            {
                x = 5f;
                select = false;
                moving = true;
            }
            if (Input.GetKey("left") && select == true)
            {
                x = -5f;
                select = false;
                moving = true;
            }
            if (Input.GetKey("up") && select == true)
            {
                y = 5f;
                select = false;
                moving = true;
            }
            if (Input.GetKey("down") && select == true)
            {
                y = -5f;
                select = false;
                moving = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "dummy" || collision.gameObject.tag == "Battery" || collision.gameObject.tag == "wall" || collision.gameObject.tag == "switch")
        {
            x = 0f;
            y = 0f;
            moving = false;
        }
    }

    void OnMouseExit()
    {
        r.color = og;
        over = false;
        select = false;
    }
}