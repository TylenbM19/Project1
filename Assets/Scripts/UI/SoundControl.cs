using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SoundControl : MonoBehaviour
{
    [SerializeField] private Sprite _imageOn, _imageOff;
    [SerializeField] private Image _image;

    private Button _button;

    public event Action OnClickIcon;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ClickHandler);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ClickHandler);
    }

    private void ClickHandler()
    {
        OnClickIcon?.Invoke();
    }

    public void ChangeIcon(bool isOn)
    {
        _image.sprite = isOn ? _imageOn : _imageOff;
    }
}
