using UnityEngine;

public class LosingVictory : UI
{
    [SerializeField] private Animator _word;
    [SerializeField] private FinishPoint _finishPoint;

    private const string _wordWin = "WordFinish";

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
    }

    private void ShowText()
    {
        _word.Play(_wordWin);
    }
}
