using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public float speed = 2.5f;
    public float amplitude = 2f;
    public float frequency = 2f;
    private Vector3 startPos;
    public GameObject explosionPrefab;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float xOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPos.x + xOffset, transform.position.y - speed * Time.deltaTime, 0);

        if (transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance?.LoseLife(1);
            Die();
        }
    }
}

