using System;
using UnityEngine;

public abstract class UI : MonoBehaviour , IUi
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public event Action IsClick;

    public void EnableCanvasGroup() => _canvasGroup.gameObject.SetActive(true);
    public void DisableCanvasGroup() => _canvasGroup.gameObject.SetActive(false);
}
