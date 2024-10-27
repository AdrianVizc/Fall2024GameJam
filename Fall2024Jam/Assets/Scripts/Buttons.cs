using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private AudioClip buttonSFX;
    [SerializeField] private float delayBeforeSceneLoad = 1f;

    public void PlayButton()
    {
        SoundFXManager.instance.PlaySFX(buttonSFX, transform, 1f);
        StartCoroutine(LoadSceneAfterDelay("LevelScene"));
    }

    public void MainMenuButton()
    {
        SoundFXManager.instance.PlaySFX(buttonSFX, transform, 1f);
        StartCoroutine(LoadSceneAfterDelay("MainMenuScene"));
    }

    public void QuitButton()
    {
        SoundFXManager.instance.PlaySFX(buttonSFX, transform, 1f);
        StartCoroutine(QuitAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(delayBeforeSceneLoad);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator QuitAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeSceneLoad);
        Application.Quit();
        Debug.Log("Quit");
    }
}
