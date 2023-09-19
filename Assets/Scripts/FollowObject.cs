using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; // Reference to the target object
    public float smoothSpeed = 0.125f; // Controls the smoothness of camera movement
    public Vector3 offset; // Offset from the target's position
    public float minDistance = 1.0f; // Minimum distance before the camera starts following
    public float maxDistance = 10.0f; // Maximum distance the camera can be from the target

    private Vector3 initialPosition; // Initial position of the camera

    void Start()
    {
        // Store the initial position of the camera
        initialPosition = transform.position;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position of the camera to center on the target
            Vector3 desiredPosition = target.position + offset;

            // Calculate the distance between the camera and target
            float distance = Vector3.Distance(transform.position, target.position);

            // Limit the camera's distance from the target
            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            // Only update the camera's position if the target moves out of the camera's view
            if (distance > minDistance)
            {
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

                // Update the camera's position
                transform.position = smoothedPosition;
            }
        }
    }
}
