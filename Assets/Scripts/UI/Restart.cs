using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : UI
{
    [SerializeField] private Button _button;
    [SerializeField] private FinishPoint _point;

    private float _delayTimeRestartGame = 1f;

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
        PlaySoundPushButtom();
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {        
        yield return new WaitForSeconds(_delayTimeRestartGame);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
