using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ScoreManager _scoreManager;
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _winScoreText;
    [SerializeField]
    private TextMeshProUGUI _bestScoreText;
    private bool _isGameOver;
    [SerializeField]
    private float _winScore;
    public bool GetIsGameOver => _isGameOver;
    [SerializeField]
    private GameObject _canvasGameOver;
    [SerializeField]
    private GameObject _canvasWinPanel;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void GameOver()
    {
        _scoreManager.SaveBestScore();
        _scoreText.text = "Score: " + _scoreManager.GetScore;
        _bestScoreText.text = "Best Score: " + _scoreManager.GetBestScore();
        _isGameOver = true;
        _canvasGameOver.SetActive(true);
    }
    public void CheckWin()
    {
        if(_scoreManager.GetScore >= _winScore && _isGameOver == false)
        {
            Win();
        }
    }
    private void Win()
    {
        _isGameOver = true;
        _canvasWinPanel.SetActive(true);
        _winScoreText.text = "Score: " + _scoreManager.GetScore;
    }
}
