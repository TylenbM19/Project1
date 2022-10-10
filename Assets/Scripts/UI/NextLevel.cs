using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : UI
{
    [SerializeField] private FinishPoint _finishPoint;
    [SerializeField] private Button _button;
    [SerializeField] private TextWin _textWin;

    private int _currentIndex = 1;

    private void OnEnable()
    {
        _finishPoint.NextLeval += EnableButton;
        _button.onClick.AddListener(EnableNextLevel);
    }

    private void OnDisable()
    {
        _finishPoint.NextLeval -= EnableButton;
        _button.onClick.RemoveListener(EnableNextLevel);
    }

    private void Start()
    {
        _button.gameObject.SetActive(false);
        _textWin.gameObject.SetActive(false);
    }

    private void EnableButton()
    {
        
        _button.gameObject.SetActive(true);
        _textWin.gameObject.SetActive(true);
    }

    private void EnableNextLevel()
    {
        PlaySoundPushButtom();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _currentIndex);
    }
}
