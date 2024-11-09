using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGrab : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool canGrab;
    public bool isGrabbed;

    public Transform playerTransform;
    public Movement playerMovement;

    public float followDistance;

    public float speed; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player entered the trigger
        if (collision.CompareTag("Player"))
        {
            canGrab = true;
            playerTransform = collision.transform;
            playerMovement = playerTransform.GetComponent<Movement>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canGrab = false;

            if (!isGrabbed)
            {
                playerTransform = null;
                playerMovement = null;
            }
        }
    }

    private void Update()
    {
        Grab();
        FollowPlayer();
    }

    private void Grab()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canGrab && !isGrabbed)
        {
            isGrabbed = true;
            rb = GetComponent<Rigidbody2D>();
            rb.freezeRotation = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrabbed)
        {
            isGrabbed = false;
            rb.freezeRotation = false;
            rb = null;
            
        }
    }

    private void FollowPlayer()
    {

        
        // Only execute if the object is grabbed and references are assigned
        if (isGrabbed && playerTransform != null && playerMovement != null)
        {
            // Calculate the target position based on player's position and movement
            Vector2 targetPosition = (Vector2)playerTransform.position - playerMovement.movement.normalized * followDistance;
            transform.position = Vector2.Lerp(transform.position, targetPosition, playerMovement.moveSpeed * Time.deltaTime * speed);
        }
    }
}
