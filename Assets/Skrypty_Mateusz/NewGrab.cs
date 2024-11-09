using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGrab : MonoBehaviour
{
    public int snapNumber; 

    public Rigidbody2D rb;

    public CapsuleCollider2D capsuleCollider;

    public bool canGrab;
    public bool isGrabbed;

    public Transform playerTransform;
    public Movement playerMovement;

    public float followDistance;

    public float speed;

    public float minRotation = 0f;
    public float maxRotation = 360f;

    public bool isSnapped; 

    public SnappableObject snappedObject;
    public ScreensaverBounce bounce;
    public SnapScore snapScore;
    public WordScore wordScore;


    public void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        bounce = GetComponent<ScreensaverBounce>();
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
        if (collision.CompareTag("Snap"))
        {
            // Try to assign the snappable object from the collision
            snappedObject = collision.GetComponent<SnappableObject>();
            snapScore = collision.GetComponent<SnapScore>();
            

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
        if (collision.CompareTag("Snap"))
        {
           
            snappedObject = null;
            snapScore = null;
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
            bounce.speed = 0f;
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrabbed)
        {
            bounce.speed = 2.5f;
            isGrabbed = false;
            transform.rotation = Quaternion.Euler(0f, 0f, randomZRotation);
            rb.freezeRotation = false;
            rb = null;
            Snap();
            
        }
    }

    public void FollowPlayer()
    {
        // Only execute if the object is grabbed and references are assigned
        if (isGrabbed && playerTransform != null && playerMovement != null)
        {
            // Calculate the distance between the player and the object
            float distance = Vector2.Distance(playerTransform.position, transform.position);
            //Debug.Log(distance);

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


 

    
    public void Snap()
    {
        if(!isSnapped) 
        {
            
            this.transform.position = snappedObject.snapTarget.position;
            this.transform.rotation = snappedObject.transform.rotation;
            snapScore.CheckWordNumber();
            isSnapped = true;
            bounce.speed = 0f;
            capsuleCollider.isTrigger = true;
            rb.freezeRotation = true;
            rb.bodyType = RigidbodyType2D.Static;
            

        }
        else if (isSnapped) 
        {
            capsuleCollider.isTrigger = false;
            isSnapped = false;
            bounce.speed = 2.5f;
            rb.freezeRotation = false;
            rb.bodyType= RigidbodyType2D.Dynamic;
            
        }
      
    }

  
    
}
