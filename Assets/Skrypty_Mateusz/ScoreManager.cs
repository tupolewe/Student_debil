using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int score;


    public void AddScore() 
    {
        score = score + 1;
    }

    public void RemoveScore() 
    {
        if (score >= 1)
        {
            score -= 1;
        }
        
    }
}
