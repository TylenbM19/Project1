using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : UI
{
    [SerializeField] private FinishPoint _finishPoint;
    [SerializeField] private Button _button;

    private int _currentIndex = 1;

    private void OnEnable()
    {
        _finishPoint.NextLeval += EnableCanvasGroup;
        _button.onClick.AddListener(EnableNextLevel);
    }

    private void OnDisable()
    {
        _finishPoint.NextLeval -= EnableCanvasGroup;
        _button.onClick.AddListener(EnableNextLevel);
    }

    private void Start()
    {
        DisableCanvasGroup();
    }

    private void EnableNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _currentIndex);
    }
}
