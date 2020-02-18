using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSwitch : MonoBehaviour
{
    public List<Transform> transforms; // Locations of the center of each stage
    public int currentStage = 0; // Current stage that is selected
    public float easing = 0.5f; // Variable to smooth transitioning from one stage to another

    // Moves to next stage
    public void NextStage()
    {
        currentStage += 1; // changes variable to next stage
        Vector3 newSpot = transform.position; // Creating variable for new position
        newSpot -= new Vector3(transforms[currentStage].position.x, 0, 0); // Changing variable to position of next stage
        StartCoroutine(SmoothTransition(transform.position, newSpot, easing)); // Couroutine to transition to the next stage
    }

    // Moves to previous stage
    public void LastStage()
    {
        currentStage -= 1; // changes variable to previous stage
        Vector3 newSpot = transform.position; // Creating variable for new position
        newSpot -= new Vector3(transforms[currentStage].position.x, 0, 0); // Changing variable to position of previous stage
        StartCoroutine(SmoothTransition(transform.position, newSpot, easing)); // Couroutine to transition to the previous stage
    }

    // Handles tranistion between both stage positions
    IEnumerator SmoothTransition(Vector3 startPos, Vector3 endPos, float seconds)
    {
        // Continues to loop over a certain amount of time until the current position interpolates to the new position
        float t = 0f;
        while (t <= 1.0f)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }

}
