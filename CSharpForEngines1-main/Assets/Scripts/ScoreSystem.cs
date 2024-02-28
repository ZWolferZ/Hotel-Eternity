using UnityEngine;

// Score system (Not Used)

public class ScoreSystem : MonoBehaviour
{
    public int score;

    public void AddScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
    }
}
