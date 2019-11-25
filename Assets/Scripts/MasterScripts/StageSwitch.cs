using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSwitch : MonoBehaviour
{
    public List<Transform> transforms;
    public int currentStage = 0;
    public float easing = 0.5f;

    public void NextStage()
    {
        currentStage += 1;
        Vector3 newSpot = transform.position;
        newSpot -= new Vector3(transforms[currentStage].position.x, 0, 0);
        StartCoroutine(SmoothTransition(transform.position, newSpot, easing));
    }

    public void LastStage()
    {
        currentStage -= 1;
        Vector3 newSpot = transform.position;
        newSpot -= new Vector3(transforms[currentStage].position.x, 0, 0);
        StartCoroutine(SmoothTransition(transform.position, newSpot, easing));
    }

    IEnumerator SmoothTransition(Vector3 startPos, Vector3 endPos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0f)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }

}
