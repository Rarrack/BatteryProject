using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    float lerpStart = 0.0f;
    float duration = 1.0f;
    bool lerping = false;
    Color start;

    void Awake()
    {
        lerpStart = Time.time;
        lerping = true;
        start = new Color(GetComponent<UnityEngine.UI.Image>().color.r, GetComponent<UnityEngine.UI.Image>().color.g, GetComponent<UnityEngine.UI.Image>().color.b, 0.0f);
    }

    // Use this for initialization
    void Start ()
    {
        GetComponent<UnityEngine.UI.Image>().color = new Color(GetComponent<UnityEngine.UI.Image>().color.r, GetComponent<UnityEngine.UI.Image>().color.g, GetComponent<UnityEngine.UI.Image>().color.b, 0.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (lerping)
        {
            float progress = Time.time - lerpStart;
            GetComponent<UnityEngine.UI.Image>().color = new Color(start.r, start.g, start.b, Mathf.Lerp(0.0f, 1.0f, progress / duration));
            if (duration < progress)
            {
                lerping = false;
            }
        }
        
	}
}
