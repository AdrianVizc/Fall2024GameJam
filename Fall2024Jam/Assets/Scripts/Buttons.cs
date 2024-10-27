using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private AudioClip buttonSFX;


    public void PlayButton()
    {
        SoundFXManager.instance.PlaySFX(buttonSFX, transform, 1f);
        SceneManager.LoadScene("Cutscene");
    }

    public void MainMenuButton()
    {
        SoundFXManager.instance.PlaySFX(buttonSFX, transform, 1f);
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitButton()
    {
        SoundFXManager.instance.PlaySFX(buttonSFX, transform, 1f);
        Application.Quit();
        Debug.Log("Quit");
    }

    public void PlayAgainButton()
    {
        SoundFXManager.instance.PlaySFX(buttonSFX, transform, 1f);
        SceneManager.LoadScene("LevelScene");
    }
}
