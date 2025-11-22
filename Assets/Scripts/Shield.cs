using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{

    public float shieldTime = 5f;

    public float speed = 8f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.ActivateShield(shieldTime);
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

}
