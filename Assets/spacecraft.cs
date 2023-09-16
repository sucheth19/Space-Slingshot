using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacecraft : MonoBehaviour
{
    public Transform[] Targets; // Array of all the targets.

    private Transform currentTarget;

    void Start()
    {
        currentTarget = Targets[0]; // Initialize the current target to the first target in the array.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentTarget = FindNearestRightTarget();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentTarget = FindNearestLeftTarget();
        }

        // Rotate around the current target.
        transform.RotateAround(currentTarget.position, Vector3.forward, 50 * Time.deltaTime);
    }

    Transform FindNearestRightTarget()
    {
        Transform nearestTarget = null;
        float nearestDistance = Mathf.Infinity;

        foreach (Transform target in Targets)
        {
            // Calculate the distance between the spaceship and the target.
            float distance = Vector3.Distance(transform.position, target.position);

            // Check if the target is to the right and closer than the previous nearest target.
            if (target.position.x > transform.position.x && distance < nearestDistance)
            {
                nearestTarget = target;
                nearestDistance = distance;
            }
        }

        return nearestTarget;
    }

    Transform FindNearestLeftTarget()
    {
        Transform nearestTarget = null;
        float nearestDistance = Mathf.Infinity;

        foreach (Transform target in Targets)
        {
            // Calculate the distance between the spaceship and the target.
            float distance = Vector3.Distance(transform.position, target.position);

            // Check if the target is to the left and closer than the previous nearest target.
            if (target.position.x < transform.position.x && distance < nearestDistance)
            {
                nearestTarget = target;
                nearestDistance = distance;
            }
        }

        return nearestTarget;
    }
}
