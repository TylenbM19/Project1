using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Menu :  UI
{
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonOptions;

    public event Action CallOptions;    
    private int _nextScene = 1;

    private void OnEnable()
    {
        _buttonStart.onClick.AddListener(EnabledGame);
        _buttonOptions.onClick.AddListener(EnabledOptions);
    }

    private void OnDisable()
    {
        _buttonStart.onClick.AddListener(EnabledGame);
        _buttonOptions.onClick.AddListener(EnabledOptions);
    }
    
    private void Start()
    {
        EnableCanvasGroup();
    }

    public void OpenMenu()
    {
        EnableCanvasGroup();
        gameObject.SetActive(true);
    }
 
    private void EnabledGame()
    {
        DisableCanvasGroup();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _nextScene);
    }

    private void EnabledOptions()
    {
        EnableCanvasGroup();
        CallOptions?.Invoke();        
    }
}
