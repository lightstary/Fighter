using UnityEngine;

public class Heart : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

}
