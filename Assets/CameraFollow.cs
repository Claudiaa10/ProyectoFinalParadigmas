using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Target to follow (Alice's Transform)
    public float smoothing = 5f;  // Amount of smoothing for camera movement
    Vector3 offset;  // Distance between the camera and target

    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Create a position the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;

        // Smoothly interpolate between the camera's current position and the target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
