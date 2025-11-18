using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject heartPrefab;
    public float spawnInterval = 8f;   // seconds between hearts

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnHeart();
            timer = 0f;
        }
    }

    void SpawnHeart()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        float height = cam.orthographicSize * 2f;
        float width = height * cam.aspect;

        float halfW = width / 2f;
        float halfH = height / 2f;

        Vector3 camPos = cam.transform.position;

        float x = Random.Range(camPos.x - halfW, camPos.x + halfW);
        float y = Random.Range(camPos.y - halfH, camPos.y + halfH);

        Vector3 spawnPos = new Vector3(x, y, 0f);

        Instantiate(heartPrefab, spawnPos, Quaternion.identity);
    }
}
