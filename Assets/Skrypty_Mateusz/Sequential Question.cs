using System.Collections.Generic;
using UnityEngine;

public class SequentialQuestion : MonoBehaviour
{
    public List<GameObject> gameObjects; // Assign GameObjects in the Inspector
    public int maxNumber = 5; // Set max number to 5 for sequence
    private int currentNumber = 1; // Start from 1

    public DialogueManager dialogueManager;

    public void Start()
    {
        // Activate the first GameObject at start (optional)
        //SelectGameObject(currentNumber);
    }

    public void GenerateNextNumber()
    {
        // Display and activate the GameObject for the current number
        SelectGameObject(currentNumber);

        // Increment the number, resetting to 1 if we exceed maxNumber
        currentNumber++;
        if (currentNumber > maxNumber)
        {
            currentNumber = 1;
        }
    }

    public void SelectGameObject(int number)
    {
        switch (number)
        {
            case 1:
                ActivateGameObject(1);
                break;
            case 2:
                ActivateGameObject(2);
                break;
            case 3:
                ActivateGameObject(3);
                break;
            case 4:
                ActivateGameObject(4);
                break;
            case 5:
                ActivateGameObject(5);
                break;
            default:
                Debug.Log("Number out of range");
                break;
        }
    }

    public void ActivateGameObject(int index)
    {
        if (index - 1 < gameObjects.Count)
        {
            GameObject selectedObject = gameObjects[index - 1];
            Debug.Log("Selected GameObject: " + selectedObject.name);

            // Enable the selected GameObject
            selectedObject.SetActive(true);
        }
        else
        {
            Debug.Log("GameObject at index " + index + " not found.");
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press P to generate the next number
        {
            //GenerateNextNumber();
        }
    }
}

