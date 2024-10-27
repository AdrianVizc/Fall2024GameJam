using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DifficultyMenu : MonoBehaviour
{
    [SerializeField] private GameObject difficultyPanel;

    [SerializeField] private PlayerController player;

    [SerializeField] private Timer timer;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void EasyButton()
    {
        player.SetStartingHealth(7);
        difficultyPanel.SetActive(false);
        Time.timeScale = 1f;
        timer.difficultySelected = true;
    }

    public void MediumButton()
    {
        player.SetStartingHealth(5);
        difficultyPanel.SetActive(false);
        Time.timeScale = 1f;
        timer.difficultySelected = true;
    }

    public void HardButton()
    {
        player.SetStartingHealth(3);
        difficultyPanel.SetActive(false);
        Time.timeScale = 1f;
        timer.difficultySelected = true;
    }

    public void SinisterButton()
    {
        player.SetStartingHealth(1);
        difficultyPanel.SetActive(false);
        Time.timeScale = 1f;
        timer.difficultySelected = true;
    }
}
