using UnityEngine;

public class Heart : MonoBehaviour
{
    public float floatSpeed = 2f;
    public float lifetime = 5f;
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    private void Update()
    {
        transform.Translate(new Vector3(0f, -floatSpeed, 0f) * Time.deltaTime);
    }

}
