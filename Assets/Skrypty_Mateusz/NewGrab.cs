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

    public float minRotation = 0f;
    public float maxRotation = 360f;


    public void Start()
    {
        float randomZRotation = Random.Range(minRotation, maxRotation);

        // Apply the random rotation to the object
        transform.rotation = Quaternion.Euler(0f, 0f, randomZRotation);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player entered the trigger
        if (collision.CompareTag("Player"))
        {
            canGrab = true;
            playerTransform = collision.transform;
            playerMovement = playerTransform.GetComponent<Movement>();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
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

    public void Grab()
    {

        float randomZRotation = Random.Range(minRotation, maxRotation);

        if (Input.GetKeyDown(KeyCode.Space) && canGrab && !isGrabbed)
        {
            isGrabbed = true;
            rb = GetComponent<Rigidbody2D>();
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            rb.freezeRotation = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrabbed)
        {
            isGrabbed = false;
            transform.rotation = Quaternion.Euler(0f, 0f, randomZRotation);
            rb.freezeRotation = false;
            rb = null;
            
        }
    }

    public void FollowPlayer()
    {
        // Only execute if the object is grabbed and references are assigned
        if (isGrabbed && playerTransform != null && playerMovement != null)
        {
            // Calculate the distance between the player and the object
            float distance = Vector2.Distance(playerTransform.position, transform.position);
            Debug.Log(distance);

            // Check if the distance is greater than the followDistance (to avoid immediate snapping)
            if (distance > followDistance)
            {
                // Calculate the direction from the object to the player
                Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;

                // Move the object towards the player, based on the distance and movement speed
                Vector2 targetPosition = (Vector2)playerTransform.position - directionToPlayer * followDistance;

                // Smoothly move the object towards the target position
                transform.position = Vector2.Lerp(transform.position, targetPosition, playerMovement.moveSpeed * Time.deltaTime * speed);
            }
        }
    }
}
