using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int score;

	public void AddScore()
    {
        score++;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
