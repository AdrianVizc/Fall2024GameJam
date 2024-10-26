using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CultistMovement : MonoBehaviour
{
    [SerializeField] private int randomWaitTimeLowerBound = 3;
    [SerializeField] private int randomWaitTimeUpperBound = 6;
    [SerializeField] private int randomSpeedLowerBound = 3;
    [SerializeField] private int randomSpeedUpperBound = 5;
    [SerializeField] private int randomDistanceLowerBound = -6;
    [SerializeField] private int randomDistanceUpperBound = 6;
    private Vector3 newPosIncrement;
    private Vector3 currPos;

    private float percentDone;
    private float currentTime;
    private float randomMoveTime;
    private float randomWaitTime;

    private bool alreadyMoving;
    private bool collidedWithWall;

    private void Start()
    {
        currPos = transform.position;
        alreadyMoving = false;
        collidedWithWall = false;
    }
    private void FixedUpdate()
    {
        if (!alreadyMoving)
        {
            StartCoroutine(MoveCultist());
        }
        alreadyMoving = true;
    }

    private IEnumerator MoveCultist()
    {
        randomWaitTime = Random.Range(randomWaitTimeLowerBound, randomWaitTimeUpperBound);
        yield return new WaitForSeconds(randomWaitTime);
        currentTime = 0.0f;
        randomMoveTime = Random.Range(randomSpeedLowerBound, randomSpeedUpperBound);

        if (!collidedWithWall)
        {
            newPosIncrement = currPos + new Vector3(Random.Range(randomDistanceLowerBound, randomDistanceUpperBound), Random.Range(randomDistanceLowerBound, randomDistanceUpperBound), 0);
        }
        else
        {
            collidedWithWall = false;
        }

        while (currentTime < randomMoveTime && !collidedWithWall)
        {
            transform.position = Vector2.Lerp(currPos, newPosIncrement, percentDone);
            percentDone = currentTime / randomMoveTime;
            currentTime += Time.deltaTime;

            if (currentTime >= randomMoveTime)
            {
                currPos = transform.position;
                alreadyMoving = false;
            }
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            alreadyMoving = false;
            collidedWithWall = true;
            newPosIncrement = currPos;
            currPos = transform.position;
        }
    }

    private void RandomDirection()
    {

    }
}
