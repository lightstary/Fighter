using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public float speed = 2.5f;       // vertical speed
    public float amplitude = 2f;     // wave width
    public float frequency = 2f;     // wave speed
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float xOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPos.x + xOffset, transform.position.y - speed * Time.deltaTime, 0);

        if (transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
    }
}
