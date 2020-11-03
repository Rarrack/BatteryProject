using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveInput : MonoBehaviour {

    //still have to get rid of the collision issue

    private Color og; //original color

    private SpriteRenderer r;

    public bool over;
    public bool select;
    //public bool moving;

    public bool charged;

    public moveBoolHolder check;

    public float x;
    public float y;

    public bool enable;

    void Start () {
        r = GetComponent<SpriteRenderer>();

        og = r.color;

        over = false;
        select = false;
        //moving = false;

        charged = false;

        x = 0f;
        y = 0f;

        enable = true;
	}
	
	void Update () {
        transform.Translate(x * Time.deltaTime, y * Time.deltaTime, 0f, Space.World);
        //Debug.Log("x = " + x + " y = " + y);
    }

    void OnMouseOver()
    {
        if (check.moving == false && enable == true)
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
                check.moving = true;
            }
            if (Input.GetKey("left") && select == true)
            {
                x = -5f;
                select = false;
                check.moving = true;
            }
            if (Input.GetKey("up") && select == true)
            {
                y = 5f;
                select = false;
                check.moving = true;
            }
            if (Input.GetKey("down") && select == true)
            {
                y = -5f;
                select = false;
                check.moving = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "dummy" || collision.gameObject.tag == "Battery" || collision.gameObject.tag == "wall" || collision.gameObject.tag == "switch") //maybe add the plug tag here
        {
            x = 0f;
            y = 0f;
            check.moving = false;

            /*
            foreach (ContactPoint2D hitPos in collision.contacts)
            {
                if(hitPos.normal.y > 0)
                {
                    Debug.Log(collision.gameObject.name + " Hit the Top: " + hitPos.normal.y);
                    transform.localPosition -= new Vector3(0, 0.03f, 0);
                }
                if (hitPos.normal.y < 0)
                {
                    Debug.Log(collision.gameObject.name + " Hit the Bottom: " + hitPos.normal.y);
                    transform.localPosition += new Vector3(0, 0.03f, 0);
                }
                if (hitPos.normal.x > 0)
                {
                    Debug.Log(collision.gameObject.name + " Hit the Right: " + hitPos.normal.x);
                    transform.localPosition -= new Vector3(0.03f, 0, 0);
                }
                if (hitPos.normal.x < 0)
                {
                    Debug.Log(collision.gameObject.name + " Hit the Left: " + hitPos.normal.x);
                    transform.localPosition += new Vector3(0.03f, 0, 0);
                }
            }
            */
        }
    }
    
    void OnMouseExit()
    {
        r.color = og;
        over = false;
        select = false;
    }
}