using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchToGame()
    {
        SceneManager.LoadScene("GameScreen"); 
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
