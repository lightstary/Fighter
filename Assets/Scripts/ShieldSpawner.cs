using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    public GameObject shieldPrefab;
    public float spawnInterval = 10f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnShield();
            timer = 0f;
        }
    }

    void SpawnShield()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        float x = Random.Range(0f, 1f);
        float y = Random.Range(0f, 0.5f);

        Vector3 vp = new Vector3(x, y, cam.nearClipPlane);
        Vector3 worldPos = cam.ViewportToWorldPoint(vp);
        worldPos.z = 0f;

        Instantiate(shieldPrefab, worldPos, Quaternion.identity);
    }
}