using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappableObject : MonoBehaviour
{
    public Transform snapTarget; // The target position where objects will snap to
    public float snapRange = 1f; // The range within which the object will snap

    public bool canSnap;

    public NewGrab newGrab;

     

    // No need to change this since snapping logic is handled in grabchuj

    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Word"))
        {
            canSnap = true;
            newGrab = collision.GetComponent<NewGrab>();

            
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Word"))
        {
            canSnap = false;
            newGrab = null;
        }
    }

   
}
