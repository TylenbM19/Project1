using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayList : MonoBehaviour
{
    [SerializeField] private AudioSource _mainMenu;
    [SerializeField] private AudioSource _clickButton;
    [SerializeField] private UI[] _ui;
    [SerializeField] private SoundControl _soundControl;

    private bool _isPlaying ;

    private void OnEnable()
    {
        _soundControl.IsSwitching += SwitchSound;

        foreach (UI ui in _ui)
        {
            ui.IsClick += EnableSoundClickButton;
        }
    }

    private void OnDisable()
    {
        _soundControl.IsSwitching -= SwitchSound;

        foreach (UI ui in _ui)
        {
            ui.IsClick -= EnableSoundClickButton;
        }
    }

    private void SwitchSound(bool isPlaying)
    {
        _isPlaying = isPlaying;
        EnableSoundClickButton();
        EnableSoundMainMenu();
    }

    private void EnableSoundClickButton()
    {
        if (!_isPlaying)
        {
            _clickButton.Stop();
            return;
        }
        _clickButton.Play();
    }

    private void EnableSoundMainMenu()
    {
        if (!_isPlaying)
        {
            _mainMenu.Stop();
            return;
        }
        _mainMenu.Play();
    }
}
