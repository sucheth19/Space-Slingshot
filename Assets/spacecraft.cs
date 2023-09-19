using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spacecraft : MonoBehaviour
{
    public Transform[] Targets; // Array of all the planets.
    private Transform currentTarget;
    private bool isMovingStraight = false; // Flag to determine if the spacecraft should move in a straight line.
  
    void Start()
    {
        currentTarget = Targets[0]; // Initialize the current target to the first planet in the array.
    }

    void Update()
    {
       
        
        // Check for proximity to planets and switch the target accordingly.
        CheckPlanetProximity();

        if (isMovingStraight)
        {
            // Move in a straight line (adjust the direction and speed as needed).
            
            transform.Translate(Vector3.left * Time.deltaTime *80f);
        }
        else
        {
            // Rotate around the current target.
            transform.RotateAround(currentTarget.position, Vector3.forward, 150 * Time.deltaTime);
        }

        // Check for spacebar input to toggle between straight and circling movement.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key is pressed");
            isMovingStraight = !isMovingStraight;
            if (isMovingStraight)
            {
                // Move in a straight line (adjust the direction and speed as needed).

                transform.Translate(Vector3.left * Time.deltaTime * 80f);
            }
            else
            {
                // Rotate around the current target.
                transform.RotateAround(currentTarget.position, Vector3.forward, 150 * Time.deltaTime);
            }

        }
    }

    void CheckPlanetProximity()
    {
        // Minimum distance to consider proximity to a planet.
        float proximityDistance = 3.0f;

        foreach (Transform planet in Targets)
        {
            float distance = Vector3.Distance(transform.position, planet.position);
            
            // If the spacecraft is close enough to a planet, switch the target.
            if (distance < proximityDistance && currentTarget!=planet)
            {
                currentTarget = planet;
                isMovingStraight = false; // Ensure circling mode is active.
                break; // Exit the loop once a nearby planet is found.
            }
        }
    }
}
