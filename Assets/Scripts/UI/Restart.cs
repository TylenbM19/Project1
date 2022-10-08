using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : UI
{
    [SerializeField] private Button _button;
    [SerializeField] private FinishPoint _point;

    private void OnEnable()
    {
        _point.RestartLeval += EnableButton;
        _button.onClick.AddListener(PressButtonRestartLevel);
    }

    private void OnDisable()
    {
        _point.RestartLeval -= EnableButton;
        _button.onClick.RemoveListener(PressButtonRestartLevel);
    }

    private void Start()
    {
        _button.gameObject.SetActive(false);
    }

    private void EnableButton()
    {
        _button.gameObject.SetActive(true);
        EnableCanvasGroup();
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
