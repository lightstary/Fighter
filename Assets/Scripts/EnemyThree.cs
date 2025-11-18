using UnityEngine;

public class EnemyThree : MonoBehaviour
{
    public float speed = 3f;
    private float directionX = 1f;
    public GameObject explosionPrefab;

    void Update()
    {
        transform.Translate(new Vector3(directionX, -1, 0) * speed * Time.deltaTime);

        // Reverse horizontal direction at screen edges
        if (transform.position.x > 9f || transform.position.x < -9f)
        {
            directionX *= -1f;
        }

        // Destroy if off-screen at bottom
        if (transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // lose 1 life
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoseLife(1);
            }

            // spawn explosion at this enemy's position
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            // destroy this enemy
            Destroy(gameObject);
        }
    }
}
