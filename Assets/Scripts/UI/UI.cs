using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI : MonoBehaviour , IUi
{
    [SerializeField] private CanvasGroup _canvasGroup;

    private const float _maxValue = 1f;
    private const float _minValue = 0f;

    public void EnableCanvasGroup() => _canvasGroup.gameObject.SetActive(true);
    public void DisableCanvasGroup() => _canvasGroup.gameObject.SetActive(false);
}
