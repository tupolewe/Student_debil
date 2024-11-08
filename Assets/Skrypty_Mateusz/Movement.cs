using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isMoving;
    public float moveSpeed;
    public Rigidbody2D rb;

    public bool inBattle = false;

    public Vector2 movement; // Make this public so other scripts can access it if needed

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (!inBattle)
        {
            // Get input for movement
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // Set isMoving based on movement input
            if (movement != Vector2.zero)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
    }

    private void FixedUpdate()
    {
        // Apply movement to the Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
