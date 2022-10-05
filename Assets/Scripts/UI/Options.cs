using UnityEngine;
using UnityEngine.UI;

public class Options : UI
{
    [SerializeField] private Slider _volueSound;
    [SerializeField] private Button _exit;
    [SerializeField] private Menu _menu;

    private void OnEnable()
    {
        _exit.onClick.AddListener(ReturnMenu);
    }

    private void OnDisable()
    {
        _exit.onClick.RemoveListener(ReturnMenu);
    }

    private void Start()
    {
        DisableCanvasGroup();
    }

    public void OpenOptions()
    {
        EnableCanvasGroup();
    }

    private void ReturnMenu()
    {
        _menu.OpenMenu();
        DisableCanvasGroup();
    }
}
