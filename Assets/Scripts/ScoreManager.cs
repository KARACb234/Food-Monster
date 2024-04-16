using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    public int GetScore => _score;
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    public void AddScore(int score)
    {
        _score += score;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = "Score: " + _score;
    }
    public int GetBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BEST_SCORE");
        return bestScore;
    }

    public void SaveBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BEST_SCORE");
        if (bestScore < _score)
        {
            PlayerPrefs.SetInt("BEST_SCORE", _score);
            PlayerPrefs.Save();
        }
    }
}
