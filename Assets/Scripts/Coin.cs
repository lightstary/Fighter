using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Coin : MonoBehaviour
{
    public float lifeTime = 3f;           // how long it stays if not collected
    public bool movesLikeEnemy = false;   // toggle movement on/off
    public float moveSpeed = 3f;          // movement speed if enabled

    private void Start()
    {
        // auto-destroy after a while so old coins don’t pile up
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // OPTIONAL: move like an enemy (from right to left)
        if (movesLikeEnemy)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(1); // +1 score
            }

            Destroy(gameObject);
        }
    }
}