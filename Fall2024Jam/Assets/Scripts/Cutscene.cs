using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public float delay = 5f;

    [SerializeField] int num_scene;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SwitchScene", delay);
    }

    // Update is called once per frame
    void SwitchScene()
    {
        SceneManager.LoadScene(num_scene);
    }
}
