using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float smoothTime = 0.3f; // Adjust this value to control the smoothness of the camera movement
    private Vector3 velocity = Vector3.zero;
    private bool isMoving = false;

    private void Start()
    {
        // Set the camera's initial position to the start position
        transform.position = startPosition;
    }

    public void MoveCamera()
    {
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            // Smoothly move the camera towards the end position
            transform.position = Vector3.SmoothDamp(transform.position, endPosition, ref velocity, smoothTime);

            // Check if camera has reached close to the end position
            if (Vector3.Distance(transform.position, endPosition) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
}