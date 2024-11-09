using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapScore : MonoBehaviour
{

    public int snapNumber;
    public WordScore wordScore; 

    public ScoreManager scoreManager;

   
    public void CheckWordNumber()
    {
        Debug.Log("check score");

       if (wordScore.wordNumber == snapNumber) 
        {
            scoreManager.AddScore();
        }
       else
        {
            scoreManager.RemoveScore();
        }
    }




   

    public void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.CompareTag("Word"))
        {
            wordScore = collision.GetComponent<WordScore>();

        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Word"))
        {
            wordScore = null; 
        }
       
    }
}