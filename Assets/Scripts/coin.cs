using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class coin : MonoBehaviour
{
    public float lifeTime = 3f;           // how long it stays if not collected
    public bool movesLikeEnemy = false;   // toggle movement on/off
    public float moveSpeed = 3f;

    private void Start()
    {
        Destroy(gameObject, lifeTime); // self-destruct timer
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
