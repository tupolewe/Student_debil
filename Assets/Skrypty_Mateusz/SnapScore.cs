using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapScore : MonoBehaviour
{

    public int snapNumber;
    public WordScore wordScore; 

    public ScoringManager manager;

   
    public void CheckWordNumber()
    {
        

       if (wordScore.wordNumber == snapNumber) 
        {
            manager.AddScore();
        }
       else
        {
            manager.RemoveScore();
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
