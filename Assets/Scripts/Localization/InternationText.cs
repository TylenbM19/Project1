using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class InternationText : MonoBehaviour
{
    [SerializeField] private Localization _localization;
    [SerializeField] private string _ru;
    [SerializeField] private string _en;
    [SerializeField] private string _tr;

    private TextMeshProUGUI _textMesh;

    private void OnEnable()
    {
        _localization.LanguageChanged += OnLanguageChanged;
    }

    private void OnDisable()
    {
        _localization.LanguageChanged -= OnLanguageChanged;
    }

    private void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void OnLanguageChanged(Language language)
    {
        switch (language)
        {
            case Language.Russian:
                _textMesh.text = _ru;
                break;
            case Language.English:
                _textMesh.text = _en;
                break;
            case Language.Turkish:
                _textMesh.text = _tr;
                break;
        }
    }
}
