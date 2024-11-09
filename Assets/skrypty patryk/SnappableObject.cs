using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappableObject : MonoBehaviour
{
    public Transform snapTarget; // The target position where objects will snap to
    public float snapRange = 1f; // The range within which the object will snap

    // No need to change this since snapping logic is handled in grabchuj
}
