using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaineMenu : MonoBehaviour
{
    public float currentTime = 5f;
    void Update()
    {
        MenuTimer();
    }

    public void MenuTimer()
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
            
        }

    }
}