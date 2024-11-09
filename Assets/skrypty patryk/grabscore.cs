using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabscore : MonoBehaviour
{
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

    public int snapScore = 10; // Points to add for a correct snap
    private bool pointsAdded = false; // Track if points were added
    private int totalScore = 0; // Track the total score locally

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
        if (collision.CompareTag("Player"))
        {
            canGrab = true;
            playerTransform = collision.transform;
            playerMovement = playerTransform.GetComponent<Movement>();
        }
        if (collision.CompareTag("Snap"))
        {
            snappedObject = collision.GetComponent<SnappableObject>();
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
        if (isGrabbed && playerTransform != null && playerMovement != null)
        {
            float distance = Vector2.Distance(playerTransform.position, transform.position);

            if (distance > followDistance)
            {
                Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;
                Vector2 targetPosition = (Vector2)playerTransform.position - directionToPlayer * followDistance;
                transform.position = Vector2.Lerp(transform.position, targetPosition, playerMovement.moveSpeed * Time.deltaTime * speed);
            }
        }
    }

    public void Snap()
    {
        if (!isSnapped && snappedObject != null)
        {
            // Snap the object
            this.transform.position = snappedObject.snapTarget.position;
            this.transform.rotation = snappedObject.transform.rotation;
            isSnapped = true;
            bounce.speed = 0f;
            capsuleCollider.isTrigger = true;
            rb.freezeRotation = true;
            rb.bodyType = RigidbodyType2D.Static;

            // Add score only if points haven't been added yet
            if (!pointsAdded)
            {
                totalScore += snapScore;
                pointsAdded = true; // Mark points as added to prevent repeats
                Debug.Log("Total Score: " + totalScore); // Display the score
            }
        }
        else if (isSnapped)
        {
            capsuleCollider.isTrigger = false;
            isSnapped = false;
            bounce.speed = 2.5f;
            rb.freezeRotation = false;
            rb.bodyType = RigidbodyType2D.Dynamic;

            // Reset pointsAdded to allow scoring if the object is unsnapped and re-snapped
            pointsAdded = false;
        }
    }
}
