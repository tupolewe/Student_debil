using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string characterName;
        [TextArea(3, 10)]
        public string dialogueText;
        public int characterID; // 0 for character 1, 1 for character 2
    }

    public TextMeshPro dialogueTextUI1; // UI Text for character 1
    public GameObject dialogueBox1; // Dialogue box for character 1

    public TextMeshPro dialogueTextUI2; // UI Text for character 2
    public GameObject dialogueBox2; // Dialogue box for character 2

    public List<DialogueLine> dialogueLines; // List of all dialogue lines
    public int currentLineIndex = 0;

    public SequentialQuestion sequentialQuestion; 

    public bool inGameplay; 

    public void Start()
    {
        inGameplay = false;

        if (dialogueLines.Count > 0)
        {
            DisplayDialogueLine();
        }
        else
        {
            Debug.LogWarning("No dialogue lines found!");
            EndDialogue();
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !inGameplay)
        {
            AdvanceDialogue();
        }
        

        

        
    }

    public void DisplayDialogueLine()
    {
        if (currentLineIndex < dialogueLines.Count)
        {
            DialogueLine currentLine = dialogueLines[currentLineIndex];

            // Toggle UI based on characterID
            if (currentLine.characterID == 0)
            {
                ShowCharacter1Dialogue(currentLine);
            }
            else if (currentLine.characterID == 1)
            {
                ShowCharacter2Dialogue(currentLine);
            }
        }
        else
        {
            EndDialogue();
        }
    }

    public void ShowCharacter1Dialogue(DialogueLine line)
    {
        dialogueBox1.SetActive(true);
        dialogueBox2.SetActive(false);

        
        dialogueTextUI1.text = line.dialogueText;
    }

    public void ShowCharacter2Dialogue(DialogueLine line)
    {
        dialogueBox2.SetActive(true);
        dialogueBox1.SetActive(false);

        
        dialogueTextUI2.text = line.dialogueText;
    }

    public void AdvanceDialogue()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Count)
        {
            DisplayDialogueLine();
        }
        else
        {
            EndDialogue();
        }

        if (currentLineIndex == 6)
        {
            Debug.Log("losowanie questa");
            sequentialQuestion.GenerateNextNumber();
            inGameplay = true;

        }
    }

    public void EndDialogue()
    {
        dialogueBox1.SetActive(false);
        dialogueBox2.SetActive(false);
        Debug.Log("Dialogue ended.");
    }

    public void QuestionStart()
    {
        if(currentLineIndex == 6)
        {
            sequentialQuestion.GenerateNextNumber();
        }
       
    }

}
