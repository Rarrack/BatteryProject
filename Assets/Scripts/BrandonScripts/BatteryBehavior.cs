using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatteryBehavior : MonoBehaviour
{
    public bool selected = false;
    float speed = 100.0f;//100.0f;
    bool hasMoved = false;

    public bool charged = true;

    private Vector3 currentDirection = Vector3.zero;

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

    void Start ()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
	}

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D[] hits = Physics2D.RaycastAll(rayPos, Vector2.zero, 0.01f);
            
            for(int i = 0; i < hits.Length; i++)
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

        if(this.selected == true && GetComponent<Rigidbody2D>().velocity.Equals(Vector3.zero) && hasMoved == true)
        {
            //Debug.Log("Collided");
            ResetMovement();
        }
        

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
                if(col.gameObject.GetComponent<BatteryWin>().needsRotate == true)
                {
                    if(gameObject.transform.rotation.z == 180)
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
    #region Mouse Movement Code
    /*
    void OnMouseDrag()
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
            }
        }
    }
    
    void OnMouseUp()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D[] hits = Physics2D.RaycastAll(rayPos, Vector2.zero, 0.01f);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.tag != "Battery")
            {
                if (this.selected == true && currentDirection.Equals(Vector3.zero))
                {
                    Vector3 inputDirection = Vector3.zero;

                    if (Camera.main.WorldToScreenPoint(this.transform.localPosition).x < rayPos.x)
                    {
                        inputDirection = new Vector3(1, 0, 0);
                    }
                    if (Camera.main.WorldToScreenPoint(this.transform.localPosition).x > rayPos.x)
                    {
                        inputDirection = new Vector3(-1, 0, 0);
                    }
                    if (Camera.main.WorldToScreenPoint(this.transform.localPosition).y < rayPos.y)
                    {
                        inputDirection = new Vector3(0, 1, 0);
                    }
                    if (Camera.main.WorldToScreenPoint(this.transform.localPosition).y > rayPos.y)
                    {
                        inputDirection = new Vector3(0, -1, 0);
                    }

                    if (!inputDirection.Equals(Vector3.zero))
                    {
                        currentDirection = inputDirection;
                        GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                        hasMoved = true;
                    }
                }
            }
            else
            {
                if (hits[i].transform.tag == "Battery" && hits[i].transform == transform)
                {
                    this.selected = false;
                }
            }
        }
        if(hits.Length == 0)
        {
            if (this.selected == true && currentDirection.Equals(Vector3.zero))
            {
                Vector3 inputDirection = Vector3.zero;

                if (this.transform.position.x < rayPos.x)
                {
                    inputDirection = new Vector3(1, 0, 0);
                }
                if (this.transform.position.x > rayPos.x)
                {
                    inputDirection = new Vector3(-1, 0, 0);
                }
                if (this.transform.position.y < rayPos.y)
                {
                    inputDirection = new Vector3(0, 1, 0);
                }
                if (this.transform.position.y > rayPos.y)
                {
                    inputDirection = new Vector3(0, -1, 0);
                }

                if (!inputDirection.Equals(Vector3.zero))
                {
                    currentDirection = inputDirection;
                    GetComponent<Rigidbody2D>().velocity = currentDirection * speed;
                    hasMoved = true;
                }
            }
        }
    }
    */
    #endregion
}
