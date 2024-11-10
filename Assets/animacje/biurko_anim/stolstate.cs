using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stolstate: MonoBehaviour
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
    public void TriggerSecondAnimation()
    {
        if (secondAnimator != null)
        {
            // Set the int parameter to a value greater than 0 to trigger the second animation
            secondAnimator.SetInteger("animationTrigger", 1);
        }
    }
    public void TriggerThirdAnimation()
    {
        if (secondAnimator != null)
        {
            // Set the int parameter to a value greater than 0 to trigger the second animation
            secondAnimator.SetInteger("animationTrigger", 2);
        }
    }
}
