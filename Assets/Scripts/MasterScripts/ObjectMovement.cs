using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//uses Mateusz's moveInput and Brandon's BatteryBehavior
//This is a movement script for any movable object
//The charge boolean is mainly reserved for batteries for the charge mechanic

public class ObjectMovement : MonoBehaviour
{
    #region Old Mouse Controls
    /*
    //privates
    private Color original; //original color of object

    private SpriteRenderer r; //spriteRenderer of object

    //publics    
    public bool enable; //used by goals to disable movement of batteries

    public bool charged = true; //checks if object is charged, for use mainly by batteries

    public float x; //movement in x direction value

    public float y; //movement in y direction value

    public ObjectMoveBoolHolder check; //checks if anything is moving, allows only one object to move at a time
    */

    bool over; //checks if mouse is over object
    #endregion

    #region Object Behavior Variables

    public bool selected = false; //Checks if object is selected
    float speed = 10.0f; //Reponsible for base speed of movement on battery
    public ObjectMoveBoolHolder check; //Checks if anything is moving, allows only one object to move at a time

    public bool charged = true; //Checks if object is charged, for use mainly by batteries

    private Vector3 currentDirection = Vector3.zero; //Current direction the object moves in
    GameObject moves; //Holds move counter to increment movement and send info to counter

    SpriteRenderer r; //spriteRenderer of object
    Color original; //original color of object

    #endregion

    #region Object Behavior Functions

    //Accessor for charge outside of script
    public bool Charged
    {
        get
        {
            return charged;
        }
        set
        {
            charged = value;
        }
    }

    //Accessor to reset objects movement variables
    public void ResetMovement()
    {
        this.selected = false;
        //animator.SetBool("Moved Right", false);
        //animator.SetBool("Moved Left", false);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        currentDirection = Vector3.zero;
    }

    #endregion

    public Sprite victorySprite;

    // Use this for initialization
    void Start () {
        r = GetComponent<SpriteRenderer>();
        //
        original = r.color;
        //
        over = false;
        selected = false;
        charged = false;
        //enable = true;
        //
        //x = 0f;
        //y = 0f;

        GetComponent<Rigidbody2D>().freezeRotation = true;


        //Sets object to the counter in the world
        moves = GameObject.Find("Counter");

        if (charged == false)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //the translate continually updates object's movement based on the current x and y
        //transform.Translate(x * Time.deltaTime, y * Time.deltaTime, 0f, Space.World);
        if(selected == true && check.moving == false)
        {
            if (Input.GetKey("right") && selected == true)
            {
                Vector3 inputDirectionRight = new Vector3(1, 0, 0);

                GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Rolling");
                moves.GetComponent<MoveCounter>().Count();
                currentDirection = inputDirectionRight;
                GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                check.moving = true;
                r.color = original;
                //x = 7.5f;
                //check.moving = true;
                //OnMouseExit();
            }
            if (Input.GetKey("left") && selected == true)
            {
                Vector3 inputDirectionLeft = new Vector3(-1, 0, 0);

                GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Rolling");
                moves.GetComponent<MoveCounter>().Count();
                currentDirection = inputDirectionLeft;
                GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                check.moving = true;
                r.color = original;
                //x = -7.5f;
                //check.moving = true;
                //OnMouseExit();
            }
            if (Input.GetKey("up") && selected == true)
            {
                Vector3 inputDirectionUp = new Vector3(0, 1, 0);

                GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Rolling");
                moves.GetComponent<MoveCounter>().Count();
                currentDirection = inputDirectionUp;
                GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                check.moving = true;
                r.color = original;
                //y = 7.5f;
                //check.moving = true;
                //OnMouseExit();
            }
            if (Input.GetKey("down") && selected == true)
            {
                Vector3 inputDirectionDown = new Vector3(0, -1, 0);

                GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Rolling");
                moves.GetComponent<MoveCounter>().Count();
                currentDirection = inputDirectionDown;
                GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                check.moving = true;
                r.color = original;
                //y = -7.5f;
                //check.moving = true;
                //OnMouseExit();
            }
        }
	}
    
    void OnMouseOver()
    {
        //shows object as selected only if not moving
        if(check.moving == false)
        {
            r.color = Color.grey; //indicates mouse is hovering over
            over = true;
    
            //if left click occurs while mouse is hovering over object, indicates object is selected
            if(Input.GetMouseButton(0) && over == true)
            {
                r.color = Color.yellow;
                selected = true;
            }
    
            //while selected, enter a directional arrow key to move object in that direction
            //and prevent other objects from moving during the same time
            //if(Input.GetKey("right") && select == true)
            //{
            //    x = 7.5f;
            //    select = false;
            //    check.moving = true;
            //    OnMouseExit();
            //}
            //if (Input.GetKey("left") && select == true)
            //{
            //    x = -7.5f;
            //    select = false;
            //    check.moving = true;
            //    OnMouseExit();
            //}
            //if (Input.GetKey("up") && select == true)
            //{
            //    y = 7.5f;
            //    select = false;
            //    check.moving = true;
            //    OnMouseExit();
            //}
            //if (Input.GetKey("down") && select == true)
            //{
            //    y = -7.5f;
            //    select = false;
            //    check.moving = true;
            //    OnMouseExit();
            //}
        }
    }

    //if mouse moves away from object, revert color and select/over bools to normal
    void OnMouseExit()
    {
        r.color = original;
        over = false;
    }

    #region Old Collision
    ////if hits an object with the specified tags, x and y are set to 0 to stop movement and set movement check to normal
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    /*
    //     * Doesnt account for multiple batteries, might need to just make it that if it hits anything it stops
    //     */
    //    if(collision.gameObject.tag == "dummy" || collision.gameObject.tag == "Battery" || collision.gameObject.tag == "wall")
    //    {
    //        x = 0f;
    //        y = 0f;
    //        check.moving = false;
    //        /*
    //         * need to add the battery shift logic here as well at some point
    //         * maybe just add/sub the 0.03f in all directions to the object upon hit?
    //         */
    //
    //        foreach(ContactPoint2D hitPos in collision.contacts)
    //        {
    //            //had to invert how the vectors got added/subtracted compared to Object shifter
    //            //this world so long you don't rapidly click with the mouse and enter an arrow key at the same time, still needs some tweaking
    //            if(hitPos.normal.y > 0)
    //            {
    //                gameObject.transform.localPosition += new Vector3(0, 0.03f, 0);
    //            }
    //            if (hitPos.normal.y < 0)
    //            {
    //                gameObject.transform.localPosition -= new Vector3(0, 0.03f, 0);
    //            }
    //            if (hitPos.normal.x > 0)
    //            {
    //                gameObject.transform.localPosition += new Vector3(0.03f, 0, 0);
    //            }
    //            if (hitPos.normal.x < 0)
    //            {
    //                gameObject.transform.localPosition -= new Vector3(0.03f, 0, 0);
    //            }
    //        }
    //    }
    //}
    #endregion

    //When object collideds it halts all movement
    void OnCollisionEnter2D(Collision2D collision)
    {
        ResetMovement();
        check.moving = false;
        over = false;
        if (gameObject.tag != "dummy")
        {
            //animator.Play("Impact");
        }
        //GameObject.Find("__bgm").GetComponent<BGM_Manager>().StopMusic("Sound");
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().StopSound("Rolling");
    }
}