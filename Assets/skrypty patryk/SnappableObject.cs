using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappableObject : MonoBehaviour
{
    public Transform snapTarget; // The target position where objects will snap to
    public float snapRange = 1f; // The range within which the object will snap

    private void OnTriggerEnter2D(Collider2D other)
    {
        // When an object enters the snap range, check if it's a grabbed object
        if (other.CompareTag("GrabbedObject"))
        {
            // Snap the object to the target position if within snap range
            float distance = Vector2.Distance(other.transform.position, snapTarget.position);
            if (distance <= snapRange)
            {
                other.transform.position = snapTarget.position;
                other.GetComponent<grabchuj>().Snap(); // Call Snap method on the grabbed object
            }
        }
    }
}
