using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject heart;
    void Start()
    {
        InvokeRepeating("SpawnHeart", 3, 5);
    }

    void SpawnHeart()
    {
        float randomX = Random.Range(-8f, 8f);

        Instantiate(heart, new Vector3(randomX, 5f, 0f), Quaternion.identity);
    }
}
