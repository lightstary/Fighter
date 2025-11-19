using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifeTime = 0.3f; // how long the effect stays

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
