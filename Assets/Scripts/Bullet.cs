using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            var enemy = other.GetComponent<EnemyOne>();
            if (enemy != null) { enemy.Die(); }

            var enemy2 = other.GetComponent<EnemyTwo>();
            if (enemy2 != null) { enemy2.Die(); }

            var enemy3 = other.GetComponent<EnemyThree>();
            if (enemy3 != null) { enemy3.Die(); }

            Destroy(gameObject);
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}