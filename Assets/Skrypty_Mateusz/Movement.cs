using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public bool isMoving;
    public float moveSpeed;
    public Rigidbody2D rb;

    public bool inBattle = false;

    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }


    void PlayerMovement()
    {
        if (!inBattle)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (movement.x > 0 || movement.y > 0 || movement.x < 0 || movement.y < 0)
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
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
