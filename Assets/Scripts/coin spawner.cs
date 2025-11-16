using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class coinspawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 3f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f;
        }
    }

    void SpawnCoin()
    {
        Camera cam = Camera.main;

        // pick a random point in the camera view (0–1 in viewport space)
        Vector3 randomViewportPos = new Vector3(
            Random.value,      // X between 0 and 1
            Random.value,      // Y between 0 and 1
            cam.nearClipPlane + 1f // distance from camera
        );

        Vector3 worldPos = cam.ViewportToWorldPoint(randomViewportPos);

        // put it on the same Z plane as player/other sprites
        worldPos.z = 0f;

        Instantiate(coinPrefab, worldPos, Quaternion.identity);
    }
}