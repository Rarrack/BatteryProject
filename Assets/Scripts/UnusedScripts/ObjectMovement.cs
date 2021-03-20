using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//uses Mateusz's moveInput and Brandon's BatteryBehavior
//This is a movement script for any movable object
//The charge boolean is mainly reserved for batteries for the charge mechanic

public class ObjectMovement : MonoBehaviour
{

    //privates
    private Color original; //original color of object

    private SpriteRenderer r; //spriteRenderer of object

    //publics    
    public bool enable; //used by goals to disable movement of batteries

    public bool over; //checks if mouse is over object

    public bool select; //checks if object is selected

    public bool charged = true; //checks if object is charged, for use mainly by batteries

    public float x; //movement in x direction value

    public float y; //movement in y direction value

    public ObjectMoveBoolHolder check; //checks if anything is moving, allows only one object to move at a time

    // Use this for initialization
    void Start () {
        r = GetComponent<SpriteRenderer>();

        original = r.color;

        over = false;
        select = false;
        //charged = false;
        enable = true;

        x = 0f;
        y = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        //the translate continually updates object's movement based on the current x and y
        transform.Translate(x * Time.deltaTime, y * Time.deltaTime, 0f, Space.World);
	}

    void OnMouseOver()
    {
        //shows object as selected only if not moving
        if(check.moving == false && enable == true)
        {
            r.color = Color.cyan; //indicates mouse is hovering over
            over = true;

            //if left click occurs while mouse is hovering over object, indicates object is selected
            if(Input.GetMouseButton(0) && over == true)
            {
                r.color = Color.yellow;
                select = true;
            }

            //while selected, enter a directional arrow key to move object in that direction
            //and prevent other objects from moving during the same time
            if(Input.GetKey("right") && select == true)
            {
                x = 7.5f;
                select = false;
                check.moving = true;
                OnMouseExit();
            }
            if (Input.GetKey("left") && select == true)
            {
                x = -7.5f;
                select = false;
                check.moving = true;
                OnMouseExit();
            }
            if (Input.GetKey("up") && select == true)
            {
                y = 7.5f;
                select = false;
                check.moving = true;
                OnMouseExit();
            }
            if (Input.GetKey("down") && select == true)
            {
                y = -7.5f;
                select = false;
                check.moving = true;
                OnMouseExit();
            }
        }
    }

    //if mouse moves away from object, revert color and select/over bools to normal
    void OnMouseExit()
    {
        r.color = original;
        over = false;
        select = false;
    }

    //if hits an object with the specified tags, x and y are set to 0 to stop movement and set movement check to normal
    void OnCollisionEnter2D(Collision2D collision)
    {
        /*
         * Doesnt account for multiple batteries, might need to just make it that if it hits anything it stops
         */
        if(collision.gameObject.tag == "dummy" || collision.gameObject.tag == "Battery" || collision.gameObject.tag == "wall")
        {
            x = 0f;
            y = 0f;
            check.moving = false;
            /*
             * need to add the battery shift logic here as well at some point
             * maybe just add/sub the 0.03f in all directions to the object upon hit?
             */

            foreach(ContactPoint2D hitPos in collision.contacts)
            {
                //had to invert how the vectors got added/subtracted compared to Object shifter
                //this world so long you don't rapidly click with the mouse and enter an arrow key at the same time, still needs some tweaking
                if(hitPos.normal.y > 0)
                {
                    gameObject.transform.localPosition += new Vector3(0, 0.03f, 0);
                }
                if (hitPos.normal.y < 0)
                {
                    gameObject.transform.localPosition -= new Vector3(0, 0.03f, 0);
                }
                if (hitPos.normal.x > 0)
                {
                    gameObject.transform.localPosition += new Vector3(0.03f, 0, 0);
                }
                if (hitPos.normal.x < 0)
                {
                    gameObject.transform.localPosition -= new Vector3(0.03f, 0, 0);
                }
            }
        }
    }
}