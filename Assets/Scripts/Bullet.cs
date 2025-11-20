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
            Destroy(other.gameObject); // kill enemy
            Destroy(gameObject);       // destroy bullet
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}