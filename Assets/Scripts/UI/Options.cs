using UnityEngine;
using UnityEngine.UI;

public class Options : UI
{
    [SerializeField] private Menu _menu;
    [SerializeField] private Button _clouseButton;
    [SerializeField] private Slider _volueSound;
    
    private void Start()
    {
        DisableCanvasGroup();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _menu.CallOptions += Open;
        _clouseButton.onClick.AddListener(ReturnMainMenu);
    }

    private void OnDisable()
    {
        _clouseButton.onClick.AddListener(ReturnMainMenu);
        _menu.CallOptions -= Open;
    }

    private void Open()
    {
        gameObject.SetActive(true);
    }

    private void ReturnMainMenu()
    {
        DisableCanvasGroup();
        _menu.OpenMenu();
        gameObject.SetActive(false);
    }
}
