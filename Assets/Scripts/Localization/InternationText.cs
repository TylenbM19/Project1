using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InternationText : MonoBehaviour
{
    [SerializeField] private string _ru;
    [SerializeField] private string _en;
    [SerializeField] private string _tr;
 
    private void OnLanguageChanged(Language language)
    {
        ////_value.text = language switch
        //{
        //    Language.Russian => GetComponent<TextMeshProUGUI>().text = _ru,
        //    Language.English => GetComponent<TextMeshProUGUI>().text = _en,
        //    Language.Turkish => GetComponent<TextMeshProUGUI>().text = _tr,
        //    _ => _en,
        //};
    }
}
