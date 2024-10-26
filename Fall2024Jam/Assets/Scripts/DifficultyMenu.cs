using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DifficultyMenu : MonoBehaviour
{
    [SerializeField] private GameObject difficultyPanel;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void EasyButton()
    {
        difficultyPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MediumButton()
    {
        difficultyPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void HardButton()
    {
        difficultyPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
