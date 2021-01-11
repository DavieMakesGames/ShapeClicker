
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private static int _score = 0;
    public static int Score { get => _score; }

    public static void AddScore(int value)
    {
        _score += value;
    }

    public static void ResetScore()
    {
        _score = 0;
    }
    public void Update()
    {
        Debug.Log(_score + "");
    }
}
