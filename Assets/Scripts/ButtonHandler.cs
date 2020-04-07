using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("How To Play");
    }

    public void Back()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void About()
    {
        SceneManager.LoadScene("About");
    }
}
