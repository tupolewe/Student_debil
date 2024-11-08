using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScreensaverBounce : MonoBehaviour
{
    public float speed = 5f;  // Speed of the moving GameObject
    private Vector2 direction; // Current moving direction
    private Rigidbody2D rb;

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
        // Keep the GameObject moving at a constant speed
        rb.velocity = direction * speed;
    }

    // Called when the GameObject collides with another Collider2D
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if we hit a wall (by checking the GameObject's tag)
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Reflect direction based on collision normal
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Reflect direction based on collision normal
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
    }
}
