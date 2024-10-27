using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeMagnitude = 0.02f;
    [SerializeField] private float shakeTime = 0.5f;
    [SerializeField] private AudioSource thunder;

    private Camera mainCamera;

    public Vector3 cameraInitialPos;
    private Vector3 cameraIntermediatePos;

    private float cameraShakingOffsetX;
    private float cameraShakingOffsetY;

    private void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        cameraInitialPos = mainCamera.transform.position;

        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        yield return new WaitForSeconds(Random.Range(15, 20));
        thunder.Play();

        InvokeRepeating("StartShake", 0f, 0.005f);
        Invoke("StopShake", shakeTime);
    }

    private void StartShake()
    {
        cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;

        cameraIntermediatePos = mainCamera.transform.position;

        cameraIntermediatePos.x += cameraShakingOffsetX;
        cameraIntermediatePos.y += cameraShakingOffsetY;

        mainCamera.transform.position = cameraIntermediatePos;
    }

    private void StopShake()
    {
        CancelInvoke("StartShake");
        mainCamera.transform.position = cameraInitialPos;

        StartCoroutine(Shake());
    }
}
