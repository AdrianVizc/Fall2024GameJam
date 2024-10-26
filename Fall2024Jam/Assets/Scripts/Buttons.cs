using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("DifficultyScene");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void EasyButton()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void NormalButton()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void HardButton()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
