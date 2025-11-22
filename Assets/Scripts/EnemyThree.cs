using UnityEngine;

public class EnemyThree : MonoBehaviour
{
    public float speed = 3f;
    private float directionX = 1f;
    public GameObject explosionPrefab;

    void Update()
    {
        transform.Translate(new Vector3(directionX, -1, 0) * speed * Time.deltaTime);

        if (transform.position.x > 9f || transform.position.x < -9f)
        {
            directionX *= -1f;
        }

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
