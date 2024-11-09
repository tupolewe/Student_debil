using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScreensaverBounce : MonoBehaviour
{
    public float speed;  // Speed of the moving GameObject
    public Vector2 direction; // Current moving direction
    public Rigidbody2D rb;

    public NewGrab newGab; // Reference to the NewGrab component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Set the initial random direction
        direction = Random.insideUnitCircle.normalized;

        // Start moving the GameObject in the initial direction
        rb.velocity = direction * speed;
    }

    void Update()
    {
        WordMove();
    }

    // Called when the GameObject collides with another Collider2D
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if we hit a wall or other specified objects
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Word"))
        {
            // Reflect direction based on collision normal
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
    }

    public void WordMove()
    {
        // Ensure newGab is assigned before accessing it
        if (newGab != null)
        {
            // Only move if the object is not grabbed
            if (!newGab.isGrabbed)
            {
                rb.velocity = direction * speed;
            }
        }
      
    }
}

