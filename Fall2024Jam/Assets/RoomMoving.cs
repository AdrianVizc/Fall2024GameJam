using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoomMoving : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();

    public Camera cam;
    private bool isRoom1;
    private bool alreadySpawned;
    public Vector2 PosRoom1;
    public Vector2 PosRoom2;
    private Vector3 Room1Coords;
    private Vector3 Room2Coords;

    void Start()
    {
        foreach (GameObject enemy in gameObjects)
        {
            enemy.SetActive(false);
        }
        isRoom1 = true;
        Room1Coords = new Vector3(PosRoom1.x,  PosRoom1.y, -10);
        Room2Coords = new Vector3(PosRoom2.x,  PosRoom2.y, -10);
        alreadySpawned = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (alreadySpawned == false)
            {
                foreach (GameObject enemy in gameObjects)
                {
                    enemy.SetActive(true);
                }
                alreadySpawned = true;
            }            
            if (isRoom1)
            {
                MoveCamera(Room2Coords);
                isRoom1 = false;
            }
            else if (!isRoom1)
            {
                MoveCamera(Room1Coords);
                isRoom1 = true;
            }
        }
        
    }

    private void MoveCamera(Vector3 position)
    {
        cam.transform.position = position;
    }
}
