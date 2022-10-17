using System;
using UnityEngine;

public class LosingVictory : UI
{
    [SerializeField] private Animator _word;
    [SerializeField] private FinishPoint _finishPoint;

    private const string _wordWin = "WordFinish";

    public event Action IsWin;

    private void OnEnable()
    {
        _finishPoint.NextLeval += PlayWinnings;
    }

    private void OnDisable()
    {
        _finishPoint.NextLeval -= PlayWinnings;
    }

    private void PlayWinnings()
    {
        ShowText();
        IsWin?.Invoke();
    }

    private void ShowText()
    {
        _word.Play(_wordWin);
    }
}
