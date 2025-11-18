using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [Header("UI")]
    public TextMeshProUGUI scoreText;

    [Header("Enemy Prefabs")]
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab;

    [Header("Spawn Intervals (seconds)")]
    public float enemyOneInterval = 2f;
    public float enemyTwoInterval = 3.5f;
    public float enemyThreeInterval = 5f;

    [Header("Score & Lives")]
    public int score = 0;
    public int lives = 3;
    public int maxLives = 3;

    private float timerOne;
    private float timerTwo;
    private float timerThree;

    private float horizontalLimit = 9f;
    private float topSpawnY = 6.5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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

    // ---------- SCORE & LIVES ----------

    public void AddScore(int amount)
    {
        score += amount;

        // Update the UI
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        Debug.Log("Score: " + score);
    }

    // hearts use this:
    public void AddLifeOrScore()
    {
        if (lives < maxLives)
        {
            lives++;
            Debug.Log("Lives: " + lives);
        }
        else
        {
            AddScore(1);
        }
    }

    public void LoseLife(int amount = 1)
    {
        lives -= amount;
        if (lives < 0) lives = 0;
        Debug.Log("Lives: " + lives);
    }
}