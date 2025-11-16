using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // -------- SINGLETON --------
    public static GameManager Instance { get; private set; }

    [Header("Enemy Prefabs")]
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab;

    [Header("Spawn Intervals (seconds)")]
    public float enemyOneInterval = 2f;
    public float enemyTwoInterval = 3.5f;
    public float enemyThreeInterval = 5f;

    [Header("Score")]
    public int score = 0;   // total score for the game

    private float timerOne;
    private float timerTwo;
    private float timerThree;

    private float horizontalLimit = 9f;
    private float topSpawnY = 6.5f;

    private void Awake()
    {
        // basic singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timerOne += Time.deltaTime;
        timerTwo += Time.deltaTime;
        timerThree += Time.deltaTime;

        if (timerOne >= enemyOneInterval)
        {
            CreateEnemy(enemyOnePrefab);
            timerOne = 0f;
        }

        if (timerTwo >= enemyTwoInterval)
        {
            CreateEnemy(enemyTwoPrefab);
            timerTwo = 0f;
        }

        if (timerThree >= enemyThreeInterval)
        {
            CreateEnemy(enemyThreePrefab);
            timerThree = 0f;
        }
    }

    private void CreateEnemy(GameObject enemyPrefab)
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(-horizontalLimit, horizontalLimit),
            topSpawnY,
            0f
        );

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    // -------- SCORE API --------
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

    }
}