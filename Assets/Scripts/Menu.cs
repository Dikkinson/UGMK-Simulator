using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Gesture()
    {
        SceneManager.LoadScene("UGMK");
    }

    public void Stroils()
    {
        SceneManager.LoadScene("Stropili");
    }

    public void FinalTest()
    {
        SceneManager.LoadScene("FinalTest");
    }
}
