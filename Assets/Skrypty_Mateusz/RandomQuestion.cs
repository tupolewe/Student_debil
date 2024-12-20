using System.Collections.Generic;
using UnityEngine;

public class RandomQuestion : MonoBehaviour
{
    public List<GameObject> gameObjects; // Assign GameObjects in the Inspector
    public List<int> availableNumbers = new List<int>();
    public int maxNumber = 7;

    public int questionNumber; 

    public DialogueManager dialogueManager;

    public void Start()
    {
        InitializeNumbers();
        //GenerateRandomNumber();
    }

    public void InitializeNumbers()
    {
        // Populate the list with numbers from 1 to maxNumber
        availableNumbers.Clear();
        for (int i = 1; i <= maxNumber; i++)
        {
            availableNumbers.Add(i);
        }
    }

    public void GenerateRandomNumber()
    {
        // If no numbers are left, reset the list
        if (availableNumbers.Count == 0)
        {
            Debug.Log("All numbers have been generated. Restarting...");
            InitializeNumbers();
        }

        // Pick a random index from the available numbers
        int randomIndex = Random.Range(0, availableNumbers.Count);
        int randomNumber = availableNumbers[randomIndex];

        // Remove the selected number from the list to avoid repetition
        availableNumbers.RemoveAt(randomIndex);

        Debug.Log("Generated Random Number: " + randomNumber);

        // Call the switch statement to select the corresponding GameObject
        SelectGameObject(randomNumber);
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
            case 6:
                ActivateGameObject(6);
                    
                break;
            case 7:
                ActivateGameObject(7);
               
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
            // Activate or perform an action on the selected GameObject
            GameObject selectedObject = gameObjects[index - 1];
            Debug.Log("Selected GameObject: " + selectedObject.name);

            // Example action: enable the GameObject if it's inactive
            selectedObject.SetActive(true);
        }
        else
        {
            Debug.Log("GameObject at index " + index + " not found.");
        }
    }

    // Call this function whenever you want to generate a new random number
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Press Space to generate a new number
        {
            GenerateRandomNumber();
        }
    }
}
