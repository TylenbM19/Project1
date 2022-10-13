using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerToDrawALine : UI
{
    [SerializeField] private Bilder _bilder;

    private void OnEnable()
    {
        _bilder.StartDraw += DisableCanvas;
    }

    private void OnDisable()
    {
        _bilder.StartDraw -= DisableCanvas;
    }

    private void Start()
    {
        EnableCanvasGroup();
    }

    private void DisableCanvas()
    {
        DisableCanvasGroup();
    }
}
