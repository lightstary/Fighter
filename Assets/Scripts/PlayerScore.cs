using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }
}

