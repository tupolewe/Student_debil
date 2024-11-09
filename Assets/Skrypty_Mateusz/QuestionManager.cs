using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    //public RandomQuestion randomQuestion;
    public int questionNumber;

    public GameObject thisOne; 
   

    public void SetActive()
    {
        
        //if (questionNumber == randomQuestion.randomNumber)
        {
            this.gameObject.SetActive(true);
        }
            
    }
}
