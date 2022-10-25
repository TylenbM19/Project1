using Agava.YandexGames;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class InternationText : MonoBehaviour
{
    [SerializeField] private string _ru;
    [SerializeField] private string _en;
    [SerializeField] private string _tr;

    private TextMeshProUGUI _textMesh;


    private void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        OnLanguageChanged();
    }

    private void OnLanguageChanged()
    {
        switch (YandexGamesSdk.Environment.i18n.lang)
        {
            case "ru":
                _textMesh.text = _ru;
                break;
            case "tr":
                _textMesh.text = _tr;
                break;
            default:
                _textMesh.text = _en;
                break;
        }
    }
}
