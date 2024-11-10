using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerrunout: MonoBehaviour
{



    // Timer variable
    public float timer; // Time in seconds (you can adjust this in the Inspector)

    // References to the GameObjects
    public GameObject objectToDeactivate;    // GameObject to deactivate
    public GameObject objectToActivate1;     // First GameObject to activate
    public GameObject objectToActivate2;     // Second GameObject to activate
    public GameObject triggerObject;         // The GameObject that will trigger the timer when activated

    // Animator to play animation
    public Animator animator;

    public ReactionDialogue reactionDialogue; 
    public ScoringManager scoringManager;

    private bool timerStarted = false;       // To check if the timer has started

    // Function to start the countdown upon activation of the trigger object
    private void Update()
    {
        if (triggerObject.activeSelf && !timerStarted)
        {
            // Start the timer when the trigger object becomes active
            timerStarted = true;
            StartCoroutine(TimerCountdown());
        }
    }

    // Coroutine that handles the countdown
    private IEnumerator TimerCountdown()
    {
        // While the timer is greater than 0, keep counting down
        while (timer > 0)
        {
            timer -= Time.deltaTime;  // Decrease the timer each frame
            yield return null;        // Wait until the next frame
        }

        // When the timer reaches 0, perform the actions
        PerformActionsAtTimerZero();
        reactionDialogue.Reaction();
        timerStarted = false;
        timer = 25f;

    }

    // Function to perform actions when the timer reaches 0
    private void PerformActionsAtTimerZero()
    {
        // Deactivate the specified GameObject
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }

        // Activate the other two GameObjects
        if (objectToActivate1 != null)
        {
            objectToActivate1.SetActive(true);
        }
        if (objectToActivate2 != null)
        {
            objectToActivate2.SetActive(true);
        }

        // Play the desired animation (replace "YourAnimationName" with the name of the animation you want to play)
        if (animator != null)
        {
            animator.Play("student_head_close");  // Play the specific animation
        }

        // Wait until the animation finishes before returning to the entry state
        StartCoroutine(ReturnToEntryState());
    }

    // Coroutine to wait for the animation to finish and then return to the entry state
    private IEnumerator ReturnToEntryState()
    {
        // Wait for the animation to finish (you can adjust the wait time based on the length of your animation)
        // Here we assume the animation's length is 1 second. You can use `animator.GetCurrentAnimatorStateInfo()` for dynamic length.
        yield return new WaitForSeconds(1f);  // Adjust to the duration of your animation

        // After the animation finishes, return to the entry state
        if (animator != null)
        {
            // If you have a specific entry state (like a default idle state), play it directly
            animator.Play("student_blink");  // Replace "Idle" with your default state
        }
    }
}


