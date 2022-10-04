using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : UI
{
    [SerializeField] private Button _button;
    [SerializeField] private FinishPoint _point;

    private void OnEnable()
    {
        _point.RestartLeval += EnableCanvasGroup;
        _button.onClick.AddListener(PressButtonRestartLevel);
    }

    private void OnDisable()
    {
        _point.RestartLeval -= EnableCanvasGroup;
        _button.onClick.AddListener(PressButtonRestartLevel);
    }

    private void Start()
    {
        DisableCanvasGroup();
    }

    private void PressButtonRestartLevel()
    {
        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
