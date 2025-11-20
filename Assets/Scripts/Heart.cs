using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Heart : MonoBehaviour
{
    public float lifeTime = 3f;
    public bool movesLikeEnemy = false;
    public float moveSpeed = 3f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddLifeOrScore();
            }

            Destroy(gameObject);
        }
    }
}
