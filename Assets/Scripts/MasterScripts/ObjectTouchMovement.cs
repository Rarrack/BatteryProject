using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Uses Mateusz's moveInput and Brandon's BatteryTouchBehavior
//This is a movement script for any movable object

public class ObjectTouchMovement : MonoBehaviour
{
    // Variables for all Behavior
    #region Object Behavior Variables

    public bool selected = false; //Checks if object is selected
    float speed = 10.0f; //Reponsible for base speed of movement on battery
    public ObjectMoveBoolHolder check; //Checks if anything is moving, allows only one object to move at a time

    public bool charged = true; //Checks if object is charged, for use mainly by batteries

    private Vector3 currentDirection = Vector3.zero; //Current direction the object moves in
    GameObject moves; //Holds move counter to increment movement and send info to counter

    #endregion

    #region Touch Input Variables

    Vector2 pressPosition; //Position of finger when first pressed on screen
    Vector2 releasePosition; //Position of finger where released on screen

    float minSwipeDistance = 20.0f; //The minimum distance on screen required for a swipe to register

    #endregion

    Animator animator;
    // Functions for all Behavior
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
        animator.SetBool("Moved Right", false);
        animator.SetBool("Moved Left", false);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        currentDirection = Vector3.zero;
    }

    #endregion

    #region Animation Behavior function
    public void EndRotation()
    {
        animator.SetBool("Rotate 90", false);
        animator.SetBool("Rotate 0", false);
    }
    
    public void EndCharge()
    {
        animator.SetBool("Charging", false);
    }
    #endregion

    #region Touch Input Functions

    //Checks to make sure swipe is valid and sets direction and position accordingly while returning the direction of the object
    private SwipeDirection SwipeDetector()
    {
        SwipeDirection direction = SwipeDirection.None;
        if (IsSwipeDistanceGood())
        {
            if (IsVerticalSwipe())
            {
                direction = pressPosition.y - releasePosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                //SendSwipe(direction);
            }
            else
            {
                direction = pressPosition.x - releasePosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                //SendSwipe(direction);
            }
            releasePosition = pressPosition;
        }
        return direction;
    }

    //Checks if swipe made is in a +/- vertical direction
    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    //Checks if swipe made is valid based on length of the swipe
    private bool IsSwipeDistanceGood()
    {
        return VerticalMovementDistance() > minSwipeDistance || HorizontalMovementDistance() > minSwipeDistance;
    }

    //Calculates absolute value of vertical distance
    private float VerticalMovementDistance()
    {
        return Mathf.Abs(pressPosition.y - releasePosition.y);
    }

    //Calculates absolute value of horizontal distance
    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(pressPosition.x - releasePosition.x);
    }

    //Dictates direction of swipe made
    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    #endregion

    public Sprite victorySprite;
    AnimatorOverrideController overrideController;
    public AnimationClip[] idleClips;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Charged", charged);
        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;

        if (gameObject.tag == "Battery")
        {
            overrideController["Idle"] = idleClips[Random.Range(0, idleClips.Length)];
        }

        // Freezes rotation to prevent physics movement on impact with walls
        GetComponent<Rigidbody2D>().freezeRotation = true;
        

        //Sets object to the counter in the world
        moves = GameObject.Find("Counter");

        if(charged == false)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began && this.selected == false && check.moving == false)
            {
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);
                RaycastHit2D[] hits = Physics2D.RaycastAll(rayPos, Vector2.zero, 0.01f);

                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].transform.tag != "Untagged")
                    {

                        if ((hits[i].transform.tag == "Battery" || hits[i].transform.tag == "dummy") && hits[i].transform == transform)
                        {
                            this.selected = true;
                            GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Battery Select");
                        }
                        else
                        {
                            this.selected = false;
                        }
                    }
                }

                pressPosition = touch.position;
                releasePosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended && this.selected == true && currentDirection.Equals(Vector3.zero))
            {
                pressPosition = touch.position;
                SwipeDirection swipe = SwipeDetector();
                if (swipe != SwipeDirection.None)
                {
                    this.selected = false;
                    switch (swipe)
                    {
                        case SwipeDirection.Up:
                            Vector3 inputDirectionUp = new Vector3(0, 1, 0);
                            if (!inputDirectionUp.Equals(Vector3.zero))
                            {
                                if (transform.rotation.z != 0)
                                {
                                    animator.SetBool("Moved Right", true);
                                }
                                GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Rolling");
                                moves.GetComponent<MoveCounter>().Count();
                                currentDirection = inputDirectionUp;
                                GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                                check.moving = true;
                            }
                            break;
                        case SwipeDirection.Down:
                            Vector3 inputDirectionDown = new Vector3(0, -1, 0);
                            if (!inputDirectionDown.Equals(Vector3.zero))
                            {
                                if (transform.rotation.z != 0)
                                {
                                    animator.SetBool("Moved Left", true);
                                }
                                GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Rolling");
                                moves.GetComponent<MoveCounter>().Count();
                                currentDirection = inputDirectionDown;
                                GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                                check.moving = true;
                            }
                            break;
                        case SwipeDirection.Left:
                            Vector3 inputDirectionLeft = new Vector3(-1, 0, 0);
                            if (!inputDirectionLeft.Equals(Vector3.zero))
                            {
                                if (transform.rotation.z == 0)
                                {
                                    animator.SetBool("Moved Left", true);
                                }
                                GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Rolling");
                                moves.GetComponent<MoveCounter>().Count();
                                currentDirection = inputDirectionLeft;
                                GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                                check.moving = true;
                            }
                            break;
                        case SwipeDirection.Right:
                            Vector3 inputDirectionRight = new Vector3(1, 0, 0);
                            if (!inputDirectionRight.Equals(Vector3.zero))
                            {
                                if (transform.rotation.z == 0)
                                {
                                    animator.SetBool("Moved Right", true);
                                }
                                GameObject.Find("__sfx").GetComponent<SFX_Manager>().PlaySound("Rolling");
                                moves.GetComponent<MoveCounter>().Count();
                                currentDirection = inputDirectionRight;
                                GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                                check.moving = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        if (this.selected == true && GetComponent<Rigidbody2D>().velocity.Equals(Vector3.zero) && check.moving == true)
        {
            ResetMovement();
        }

        if (this.selected == true)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.2f,0.2f,0.2f,1); //Color.yellow;
        }
        else
        {
            if (gameObject.name == "AA Battery")
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
            if (gameObject.name == "9-Volt Battery")
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
            if (gameObject.name == "Dummy" || gameObject.tag == "dummy")
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    //When object collideds it halts all movement
    void OnCollisionEnter2D(Collision2D collision)
    {
        ResetMovement();
        check.moving = false;
        if (gameObject.tag != "dummy")
        {
            animator.Play("Impact");
        }
        //GameObject.Find("__bgm").GetComponent<BGM_Manager>().StopMusic("Sound");
        GameObject.Find("__sfx").GetComponent<SFX_Manager>().StopSound("Rolling");
    }
}
