using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform roomCenter;
    public float cameraMoveSpeed = 20; // Increased camera move speed

    private Camera mainCamera;
    private bool isPlayerInsideRoom = false;

    private void Start()
    {
        mainCamera = Camera.main; // Get the main camera component
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInsideRoom = true;
            MoveCameraToRoomCenter(roomCenter.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInsideRoom = false;
        }
    }

    private void Update()
    {
        // Check if the player is still inside the room trigger area
        if (isPlayerInsideRoom && Vector3.Distance(mainCamera.transform.position, roomCenter.position) > 0.1f)
        {
            MoveCameraToRoomCenter(roomCenter.position);
        }
    }

    private void MoveCameraToRoomCenter(Vector3 targetPosition)
    {
    targetPosition.z = -1; // Keep the same z position
    float moveDistance = Time.deltaTime * cameraMoveSpeed; // Calculate move distance based on speed
    mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, targetPosition, 1);
    }
}
