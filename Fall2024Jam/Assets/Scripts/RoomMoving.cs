using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoomMoving : MonoBehaviour
{
    private CameraShake cameraShake;
    public List<GameObject> gameObjects = new List<GameObject>();

    private Transform player;
    public Camera cam;
    private bool isRoom1;
    private bool alreadySpawned;
    public Vector2 PosRoom1;
    public Vector2 PosRoom2;
    public Vector2 PlayerPosition1;
    public Vector2 PlayerPosition2;
    private Vector3 Room1Coords;
    private Vector3 Room2Coords;
    private float spawnDelay = 0.2f;

    void Start()
    {
        cameraShake = GameObject.FindObjectOfType<CameraShake>();

        foreach (GameObject enemy in gameObjects)
        {
            enemy.SetActive(false);
        }
        isRoom1 = true;
        Room1Coords = new Vector3(PosRoom1.x,  PosRoom1.y, -10);
        Room2Coords = new Vector3(PosRoom2.x,  PosRoom2.y, -10);
        alreadySpawned = false;
        player = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (alreadySpawned == false)
            {
                StartCoroutine(Delay(spawnDelay));                
            }            
            if (isRoom1)
            {
                MoveCamera(Room2Coords);
                isRoom1 = false;
                MovePlayer(PlayerPosition2);
            }
            else if (!isRoom1)
            {
                MoveCamera(Room1Coords);
                isRoom1 = true;
                MovePlayer(PlayerPosition1);
            }
        }
        
    }

    private void MoveCamera(Vector3 position)
    {
        cam.transform.position = position;
        cameraShake.cameraInitialPos = position;
    }

    private void MovePlayer(Vector2 position)
    {
        player.transform.position = position;
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        foreach (GameObject enemy in gameObjects)
        {
            enemy.SetActive(true);
        }
        alreadySpawned = true;
    }
}
