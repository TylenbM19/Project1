using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : UI
{
    [SerializeField] private FinishPoint _finishPoint;
    [SerializeField] private Button _button;

    private int _currentIndex = 1;
    private float _timeDelayNewLevel = 1f;
    public event Action IsButtonClickNext;

    private void OnEnable()
    {
        _finishPoint.NextLeval += EnableButton;
        _button.onClick.AddListener(ChallengeNextLevel);
    }

    private void OnDisable()
    {
        _finishPoint.NextLeval -= EnableButton;
        _button.onClick.RemoveListener(ChallengeNextLevel);
    }

    private void Start()
    {
        _button.gameObject.SetActive(false);
    }

    private void EnableButton()
    {
        _button.gameObject.SetActive(true);
    }

    private void ChallengeNextLevel()
    {
        IsButtonClickNext?.Invoke();
        StartCoroutine(EnableNextLevel());
    }

    private IEnumerator EnableNextLevel()
    {
        yield return new WaitForSeconds(_timeDelayNewLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _currentIndex);
    }
}
