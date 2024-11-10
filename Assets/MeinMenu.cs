using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeinMenu : MonoBehaviour
{
    public void ShowHelp()
    {
        SceneManager.LoadSceneAsync("HelpScene");
    }
}