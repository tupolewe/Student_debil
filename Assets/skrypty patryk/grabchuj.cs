using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabchuj : MonoBehaviour
{
    public float followDistance = 1f; // Distance to keep from the player
    private bool isGrabbed = false;
    private Transform playerTransform;
    private Movement playerMovement; // Reference to Movement script

    private static grabchuj currentlyGrabbedObject = null;

    private Collider2D pickupCollider; // Collider to detect the pickup range

    public bool isSnapped = false; // To check if object is snapped

    void Start()
    {
        // Get the collider for the pickup zone (this is the area where the object can be grabbed)
        pickupCollider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the trigger
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            playerMovement = playerTransform.GetComponent<Movement>(); // Get Movement script attached to the player
        }
    }

    void Update()
    {
        if (playerTransform != null && Input.GetKeyDown(KeyCode.G))
        {
            if (!isGrabbed && currentlyGrabbedObject == null && IsPlayerInRange())
            {
                Grab(); // If object is not grabbed and player is in range, grab it
            }
            else if (isGrabbed)
            {
                Drop(); // If object is grabbed, drop it
            }
        }

        if (isGrabbed && playerMovement.isMoving && !isSnapped)
        {
            FollowPlayer();
        }
    }

    void Grab()
    {
        isGrabbed = true;
        currentlyGrabbedObject = this;
    }

    void Drop()
    {
        isGrabbed = false;
        currentlyGrabbedObject = null;

        // Check for snap behavior
        CheckForSnap();
    }

    void FollowPlayer()
    {
        Vector2 targetPosition = (Vector2)playerTransform.position - playerMovement.movement.normalized * followDistance;
        transform.position = Vector2.Lerp(transform.position, targetPosition, playerMovement.moveSpeed * Time.deltaTime);
    }

    bool IsPlayerInRange()
    {
        // Check if the player is within the pickup collider's bounds
        return pickupCollider.bounds.Contains(playerTransform.position);
    }

    // Check if the object should snap after dropping it
    void CheckForSnap()
    {
        // Find all snappable objects in the scene
        SnappableObject[] snappableObjects = FindObjectsOfType<SnappableObject>();

        foreach (SnappableObject snappable in snappableObjects)
        {
            float distance = Vector2.Distance(transform.position, snappable.snapTarget.position);
            if (distance <= snappable.snapRange)
            {
                // Snap the object to the target position
                transform.position = snappable.snapTarget.position;
                Snap(); // Call Snap method to update the status
                break;
            }
        }
    }

    // This will mark the object as snapped
    public void Snap()
    {
        isSnapped = true;
        // Disable further movement or interaction if needed
        // You can also add code to disable its collider if snapping means it is "settled."
        GetComponent<Collider2D>().enabled = false;
    }
}
