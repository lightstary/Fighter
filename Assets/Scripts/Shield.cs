using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{

    public float shieldTime = 5f;

    public float speed = 8f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player shield = other.GetComponent<Player>();

        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (shield != null)
        {
            shield.ActivateShield(shieldTime);
            Destroy(gameObject);
        }


        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
