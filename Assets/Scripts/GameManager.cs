using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _multiplier = 0;

    public int TimeLimit = 60;
    private float _currentTime = 60;

    public ScoreKeeper ScoreKeeper;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI MultiplierText;
    public TextMeshProUGUI CountdownText;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _currentTime = TimeLimit;
        UpdateTime();
        ScoreKeeper.ResetScore();
    }

    private void Update()
    {
        _currentTime -= 1 * Time.deltaTime;
        if(_currentTime <= 0) SceneManager.LoadScene(2);
        UpdateTime();
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
        ScoreKeeper.AddScore(1 * _multiplier);
        ScoreText.text = "Score: " + ScoreKeeper.Score;

        int hs = PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.SetInt("HighScore", Mathf.Max(hs, ScoreKeeper.Score));
    }
    public void UpdateMultiplier()
    {
        MultiplierText.text = "Multiplier: x" + _multiplier;
    }
    private void UpdateTime()
    {
        CountdownText.text = "Time: " + Mathf.RoundToInt(_currentTime);
    }
}
