using UnityEngine;

public class Tower : MonoBehaviour
{
    private int score = 0;

    public void AddScore(int value)
    {
        score += value;
    }

    public int GetScore() 
    {
        return score;
    }

    public void SetScore(int scr)
    {
        this.score = scr;
    }
}
