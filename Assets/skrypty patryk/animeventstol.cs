using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animeventstol: MonoBehaviour
{
    public GameObject secondGameObject;  // Assign the second GameObject in the Inspector
    private Animator secondAnimator;

    void Start()
    {
        if (secondGameObject != null)
        {
            secondAnimator = secondGameObject.GetComponent<Animator>();
        }
    }

    // Function to be called by the Animation Event
    public void PlaySecondAnimation()
    {
        if (secondAnimator != null)
        {
            secondAnimator.Play("STOL");  // Replace "SecondAnimation" with the actual name of the animation
        }
    }
}

