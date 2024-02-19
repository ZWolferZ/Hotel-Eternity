using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int score;

    public void AddScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
    }
}
