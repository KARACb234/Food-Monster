using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float _roundeTime;
    private float _timer;
    private bool _isOn;
    [SerializeField]
    private TextMeshProUGUI _timerText;
    [SerializeField]
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    private void StartTimer()
    {
        _timer = _roundeTime;
        _isOn = true;
        StartCoroutine(RoundeTimerCorutine());
    }
    private void EndTimer()
    {
        _isOn = false;
        _timer = 0;

        _gameManager.GameOver();
    }
    private void TimerTextUpdate()
    {
        TimeSpan time = TimeSpan.FromSeconds(_timer);
        _timerText.text ="Time:" +  string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
    }
    private IEnumerator RoundeTimerCorutine()
    {
        while(_isOn == true)
        {
            _timer -= Time.deltaTime;
            TimerTextUpdate();
            yield return new WaitForEndOfFrame();
            if(_timer < 0)
            {
                EndTimer();
                yield break;
            }
        }
        
    }
}
