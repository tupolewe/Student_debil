using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionDialogue : MonoBehaviour
{
    public ScoringManager scoringManager;
    public timerrunout timerRunOut; 
    public DialogueManager dialogueManager;
    public SequentialQuestion sequentialQuestion; 
    public Animator animator;

    private void Start()
    {
        
    }

    public void Reaction()
    {

        Debug.Log("reakcja");
        if (scoringManager.firstQuestion)
        {
            
            animator.SetInteger("IdleIndex", 5);
            dialogueManager.AdvanceDialogue();
            dialogueManager.inGameplay = false;
        }
        else if (!scoringManager.firstQuestion)
        {
            animator.SetInteger("IdleIndex", 4);
            dialogueManager.AdvanceDialogue();
            dialogueManager.inGameplay = false;
        }


       

    }

}
