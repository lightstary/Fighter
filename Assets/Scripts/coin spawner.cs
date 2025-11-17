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
        if (cam == null) return;

        // Size of the camera view in world units
        float height = cam.orthographicSize * 2f;
        float width = height * cam.aspect;

        // Half extents
        float halfWidth = width / 2f;
        float halfHeight = height / 2f;

        // Center of the camera in world space
        Vector3 camPos = cam.transform.position;

        // Random position inside the camera bounds
        float x = Random.Range(camPos.x - halfWidth, camPos.x + halfWidth);
        float y = Random.Range(camPos.y - halfHeight, camPos.y + halfHeight);

        Vector3 spawnPos = new Vector3(x, y, 0f);   // z = 0 for 2D stuff

        Instantiate(coinPrefab, spawnPos, Quaternion.identity);
    }
}
