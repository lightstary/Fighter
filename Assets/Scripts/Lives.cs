using UnityEngine;

public class Lives : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] hearts; // size 3, assign in Inspector

    private void Update()
    {
        if (GameManager.Instance == null) return;

        int lives = GameManager.Instance.lives;

        for (int i = 0; i < hearts.Length; i++)
        {
            // turn on hearts 0..lives-1, off the rest
            hearts[i].SetActive(i < lives);
        }
    }
}
