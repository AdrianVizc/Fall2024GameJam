using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Timer timer;
    public Animator transition;

    public float transitionTime = 3f;

    private GameObject ghostBoss;

    private GameObject pauseMenu;

    private bool beatGame;

    private int counter = 0;

    private void Start()
    {
        beatGame = false;
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            ghostBoss = GameObject.Find("Room 2-Boss");
            if (ghostBoss != null)
            {
                RoomMoving roomMoving = ghostBoss.GetComponent<RoomMoving>();
                for (int i = 0; i < roomMoving.GetComponent<RoomMoving>().GetListOfEnemies().Count; i++)
                {
                    if (roomMoving.GetComponent<RoomMoving>().GetListOfEnemies()[i] == null)
                    {
                        counter++;
                        //Debug.Log(counter);
                        if (counter == 6)
                        {
                            timer.endGame = true;
                            beatGame = true;
                            LoadNextLevel();
                        }
                    }
                    else
                    {
                        counter = 0;
                    }
                }
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(LoadLevel(0));
            }
        }
    }

    public void LoadNextLevel()
    {        
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (beatGame == false)
            {
                transitionTime = 1;
                pauseMenu = GameObject.Find("PauseMenu");
                pauseMenu.SetActive(false);
                StartCoroutine(LoadLevel(2));
            }
            else
            {
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            }
        }
        else
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }        
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 && beatGame)
        {
            transition.SetTrigger("BeatGame");
        }
        else 
        {
            transition.SetTrigger("Start");
        }            
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
