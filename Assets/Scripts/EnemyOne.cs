using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    public GameObject explosionPrefab;

    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 3f);

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
