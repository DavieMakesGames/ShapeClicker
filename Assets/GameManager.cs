using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int _score = 0;
    private int _multiplier = 0;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI MultiplierText;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseMultiplier()
    {
        _multiplier += 1;
        UpdateMultiplier();
    }
    public void DecreaseMultiplier()
    {
        _multiplier = Mathf.Max(0, _multiplier -= 1);
        UpdateMultiplier();
    }

    public void UpdateScore()
    {
        _score += 1 * _multiplier;
        ScoreText.text = "Score: " + _score;
    }
    public void UpdateMultiplier()
    {
        MultiplierText.text = "Multiplier: x" + _multiplier;
    }
}
