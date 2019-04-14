using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BatteryTouchBehavior : MonoBehaviour
{
    // Variables for all Behavior
    #region Battery Behavior Variables
    // Battery Behavior Variables
    public bool selected = false;
    float speed = 10.0f;//100.0f;
    bool hasMoved = false;

    public bool charged = true;

    private Vector3 currentDirection = Vector3.zero;
    GameObject moves;
    #endregion

    #region Touch Input Variables
    // Touch Input Variables
    private Vector2 pressPosition;
    private Vector2 releasePosition;

    [SerializeField]
    private bool detectSwipeAfterRelease = false;

    [SerializeField]
    private float minSwipeDistance = 20.0f;

    public static event System.Action<SwipeData> OnSwipe = delegate { };
    #endregion

    // Functions for all Behavior
    #region Battery Behavior Functions
    // Battery Behavior Functions
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

    public bool HasMoved
    {
        get
        {
            return hasMoved;
        }
        set
        {
            hasMoved = value;
        }
    }

    public void ResetDirection()
    {
        currentDirection = Vector3.zero;
    }

    public void ResetMovement()
    {
        this.selected = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        currentDirection = Vector3.zero;
    }
    #endregion

    #region Touch Input Functions
    // Touch Input Functions
    private void DetectSwipe()
    {
        if (IsSwipeDistanceGood())
        {
            if (IsVerticalSwipe())
            {
                var direction = pressPosition.y - releasePosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                //SendSwipe(direction);
            }
            else
            {
                var direction = pressPosition.x - releasePosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                //SendSwipe(direction);
            }
            releasePosition = pressPosition;
        }
    }

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

    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    private bool IsSwipeDistanceGood()
    {
        return VerticalMovementDistance() > minSwipeDistance || HorizontalMovementDistance() > minSwipeDistance;
    }

    private float VerticalMovementDistance()
    {
        return Mathf.Abs(pressPosition.y - releasePosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(pressPosition.x - releasePosition.x);
    }

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            StartPosition = pressPosition,
            EndPosition = releasePosition
        };
        OnSwipe(swipeData);
    }

    public struct SwipeData
    {
        public Vector2 StartPosition;
        public Vector2 EndPosition;
        public SwipeDirection Direction;
    }

    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right,
        None
    }
    #endregion


    void Start()
    {
        // Freezes rotation to prevent physics movement on impact with walls
        GetComponent<Rigidbody2D>().freezeRotation = true;
        moves = GameObject.Find("Counter");
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began && this.selected == false && hasMoved == false)
            {
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);
                RaycastHit2D[] hits = Physics2D.RaycastAll(rayPos, Vector2.zero, 0.01f);

                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].transform.tag != "Untagged")
                    {

                        if (hits[i].transform.tag == "Battery" && hits[i].transform == transform)
                        {
                            this.selected = true;
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

            if (!detectSwipeAfterRelease && touch.phase == TouchPhase.Moved && this.selected == true)
            {
                pressPosition = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended && this.selected == true && currentDirection.Equals(Vector3.zero))
            {
                pressPosition = touch.position;
                SwipeDirection swipe = SwipeDetector();
                if (swipe != SwipeDirection.None)
                {
                    switch (swipe)
                    {
                        case SwipeDirection.Up:
                            Vector3 inputDirectionUp = new Vector3(0, 1, 0);
                            if (!inputDirectionUp.Equals(Vector3.zero))
                            {
                                currentDirection = inputDirectionUp;
                                GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                                hasMoved = true;
                                moves.GetComponent<MoveCounter>().Counter++;
                                moves.GetComponent<MoveCounter>().Write = true;
                            }
                            break;
                        case SwipeDirection.Down:
                            Vector3 inputDirectionDown = new Vector3(0, -1, 0);
                            if (!inputDirectionDown.Equals(Vector3.zero))
                            {
                                currentDirection = inputDirectionDown;
                                GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                                hasMoved = true;
                                moves.GetComponent<MoveCounter>().Counter++;
                                moves.GetComponent<MoveCounter>().Write = true;
                            }
                            break;
                        case SwipeDirection.Left:
                            Vector3 inputDirectionLeft = new Vector3(-1, 0, 0);
                            if (!inputDirectionLeft.Equals(Vector3.zero))
                            {
                                currentDirection = inputDirectionLeft;
                                GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                                hasMoved = true;
                                moves.GetComponent<MoveCounter>().Counter++;
                                moves.GetComponent<MoveCounter>().Write = true;
                            }
                            break;
                        case SwipeDirection.Right:
                            Vector3 inputDirectionRight = new Vector3(1, 0, 0);
                            if (!inputDirectionRight.Equals(Vector3.zero))
                            {
                                currentDirection = inputDirectionRight;
                                GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                                hasMoved = true;
                                moves.GetComponent<MoveCounter>().Counter++;
                                moves.GetComponent<MoveCounter>().Write = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        if (this.selected == true && GetComponent<Rigidbody2D>().velocity.Equals(Vector3.zero) && hasMoved == true)
        {
            //Debug.Log("Collided");
            ResetMovement();
        }

        if(this.selected == true)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            if(gameObject.name == "AA Battery")
            {
                GetComponent<SpriteRenderer>().color = Color.blue;
            }
            if(gameObject.name == "D-Cell Battery")
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }

        #region Old Behavior Code
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D[] hits = Physics2D.RaycastAll(rayPos, Vector2.zero, 0.01f);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.tag != "Untagged")
                {

                    if (hits[i].transform.tag == "Battery" && hits[i].transform == transform)
                    {
                        this.selected = true;
                    }
                    else
                    {
                        this.selected = false;
                    }
                }
            }
        }

        if (this.selected == true && currentDirection.Equals(Vector3.zero))
            {
                Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
                if (!inputDirection.Equals(Vector3.zero))
                {
                    currentDirection = inputDirection;
                    GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                    hasMoved = true;
                }
            }

        */
        #endregion
    }

        void OnCollisionEnter2D(Collision2D col)
    {
        ResetMovement();
        hasMoved = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.name == "AA Battery" && col.gameObject.name == "Battery Win 2")
        {
            //Debug.Log("WIN!!!");
            if (col.gameObject.GetComponent<BatteryWin>() == null)
            {
                SceneManager.LoadScene("MainMenu");
            }
            if (col.gameObject.GetComponent<BatteryWin>() != null)
            {
                if (col.gameObject.GetComponent<BatteryWin>().needsRotate == true)
                {
                    if (gameObject.transform.rotation.z == 180)
                    {
                        SceneManager.LoadScene("MainMenu");
                    }
                }
                else
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }

        if (gameObject.name == "D-Cell Battery" && col.gameObject.name == "Battery Win 1")
        {
            col.gameObject.GetComponent<MoveWalls>().Activate = true;
        }
    }
    
}