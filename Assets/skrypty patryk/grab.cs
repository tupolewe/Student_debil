using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public float followDistance = 1f; // Distance to keep from the player
    private bool isGrabbed = false;
    private Transform playerTransform;
    private Movement playerMovement; // Reference to Movement script

    private static grab currentlyGrabbedObject = null;

    private Collider2D pickupCollider; // Collider to detect the pickup range

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

        if (isGrabbed && playerMovement.isMoving)
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
    }

    void FollowPlayer()
    {
        Vector2 targetPosition = (Vector2)playerTransform.position - playerMovement.movement.normalized * followDistance;
        transform.position = Vector2.Lerp(transform.position, targetPosition, playerMovement.moveSpeed * Time.deltaTime);
    }

    // Check if the player is within range of the object to pick it up
    bool IsPlayerInRange()
    {
        // Check if the player is within the pickup collider's bounds
        return pickupCollider.bounds.Contains(playerTransform.position);
    }
}
