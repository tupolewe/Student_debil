using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public float followDistance = 1f; // Distance to keep from the player
    public bool isGrabbed = false;
    public Transform playerTransform;
    public Movement playerMovement; // Reference to Movement script

    public static grab currentlyGrabbedObject = null;

    public bool playerInRange;

    public Collider2D pickupCollider; // Collider to detect the pickup range

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
                Debug.Log("jest player");
                playerTransform = other.transform;
                playerMovement = playerTransform.GetComponent<Movement>(); // Get Movement script attached to the player
                playerInRange = true;
                
            }
        
       
    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("jest player");
            playerTransform = null;
            playerMovement = null;
            playerInRange = false;
            
        }

        
       
    }

    void Update()
    {
        Grabbing();
    }

    public void Grab()
    {
        isGrabbed = true;
        currentlyGrabbedObject = this;
    }

    public void Drop()
    {
        isGrabbed = false;
        currentlyGrabbedObject = null;
    }

    public void FollowPlayer()
    {
        Vector2 targetPosition = (Vector2)playerTransform.position - playerMovement.movement.normalized * followDistance;
        transform.position = Vector2.Lerp(transform.position, targetPosition, playerMovement.moveSpeed * Time.deltaTime);
    }

    // Check if the player is within range of the object to pick it up
    public bool IsPlayerInRange()
    {
        // Check if the player is within the pickup collider's bounds
        return pickupCollider.bounds.Contains(playerTransform.position);
    }

    public void Grabbing()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("jest player2");

            if (!isGrabbed && currentlyGrabbedObject == null && playerInRange)
            {
                Grab(); // If object is not grabbed and player is in range, grab it
                Debug.Log("jest player3");
            }
            else if (isGrabbed)
            {

                Drop(); // If object is grabbed, drop it
                Debug.Log("jest player4");
            }
        }

        if (isGrabbed && playerMovement.isMoving)
        {
            FollowPlayer();
        }
    }
}
