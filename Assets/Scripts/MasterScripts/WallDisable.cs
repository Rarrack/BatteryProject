using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDisable : MonoBehaviour
{
    Animator animator;
    public bool disabled;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //if(disabled == false)
        //{
        //    Enable();
        //}
        //else
        //{
        //    Disable();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disable()
    {
        //Color curCol = GetComponent<SpriteRenderer>().color;
        //GetComponent<SpriteRenderer>().color = new Color(curCol.r, curCol.g, curCol.b, 0.5f);
        animator.SetBool("Open", false);
        animator.SetBool("Close", true);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Enable()
    {
        //Color curCol = GetComponent<SpriteRenderer>().color;
        //GetComponent<SpriteRenderer>().color = new Color(curCol.r, curCol.g, curCol.b, 1);
        animator.SetBool("Close", false);
        animator.SetBool("Open", true);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
