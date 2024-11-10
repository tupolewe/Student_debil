using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoringManager : MonoBehaviour
{


    public float currentTime = 5f;
    public int maxScore;
    public int score;

    public int correctQuestions;

    public bool firstQuestion;
    public bool secondQuestion;
    public bool thirdQuestion; 
    public bool fourthQuestion;
    public bool fifthQuestion;

    public float countdownTime = 5f;  // Set the countdown time (in seconds)
    

    public bool playerWon;
    public bool end;
    private bool hasLoaded = false;
    public void AddScore()
    {
        score = score + 1;
    }

    //public void RemoveScore()
    //{
        //if (score >= 1)
        //{
            //score -= 1;
        //}

    //}

    public void FirstQuestion()
    {
        if (score == 4 ) 
        {
            correctQuestions++;
            score = 0;
            firstQuestion = true;
        }
        else
        {
            score = 0;
        }
       

    }

    public void SecondQuestion()
    {
        if (score == 4)
        {
            correctQuestions++;
            score = 0;
            secondQuestion = true;
        }
        else
        {
            score = 0;
        }
    }

    public void ThirdQuestion()
    {
        if (score == 3)
        {
            correctQuestions++;
            score = 0;
            thirdQuestion = true;
        }
        else
        {
            score = 0;
        }
    }

    public void FourthQuestion()
    {
        if (score == 5)
        {
            correctQuestions++;
            score = 0;
            fourthQuestion = true;
        }
        else
        {
            score = 0;
        }
    }

    public void FifthQuestion()
    {
        if (score == 1)
        {
            correctQuestions++;
            score = 0;
            fifthQuestion = true;
        }
        else
        {
            score = 0;
        }
    }

    public void WinCondition()
    {
        if (correctQuestions >= 3)
        {
            SceneManager.LoadSceneAsync(2);
            end =true;
        }
        else
        {
            SceneManager.LoadSceneAsync(3);
            end =true;
        }
    }

    void Update()
    {
        MenuTimer();
    }
    
    public void MenuTimer()
    {

        if (end && !hasLoaded)
        {
            // Decrease the time
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                Debug.Log("Time remaining: " + Mathf.Ceil(currentTime));  // Log time to console
            }
            else
            {
                SceneManager.LoadSceneAsync(0);
                hasLoaded = true;
            }
        }
            
    }
}
