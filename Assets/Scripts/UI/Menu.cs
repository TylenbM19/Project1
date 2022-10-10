using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Menu :  UI
{
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonOptions;
    [SerializeField] private Options _options;
 
    private int _nextScene = 1;

    private void OnEnable()
    {
        _buttonStart.onClick.AddListener(EnabledGame);
        _buttonOptions.onClick.AddListener(EnabledOptions);
    }

    private void OnDisable()
    {
        _buttonStart.onClick.RemoveListener(EnabledGame);
        _buttonOptions.onClick.RemoveListener(EnabledOptions);
    }
    
    private void Start()
    {
        EnableCanvasGroup();
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);
    }
 
    private void EnabledGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _nextScene);
    }

    private void EnabledOptions()
    {
        _options.OpenOptions();
        gameObject.SetActive(false);
    }
}
