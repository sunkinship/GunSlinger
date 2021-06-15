using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene(3);
    }

    public void ButtonCredits()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonRules()
    {
        SceneManager.LoadScene(2);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
