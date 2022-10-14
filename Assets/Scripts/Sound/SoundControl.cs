using System;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    [SerializeField] private AudioSwitchView _audioSwitch;

    private VolumeEnabledPlayerPrefs _volumeEnabled = new VolumeEnabledPlayerPrefs();
    private bool _isPlaying;

    public event Action<bool> IsSwitching; 

    private void OnEnable()
    {
        _audioSwitch.OnClickIcon += Switching;
    }

    private void OnDisable()
    {
        _audioSwitch.OnClickIcon -= Switching;
    }

    private void Start()
    {
        _isPlaying = _volumeEnabled.Get();
        _audioSwitch.ChangeIcon(_isPlaying);
    }

    private void Switching()
    {
        _isPlaying = _isPlaying == true ?  false : true;
        _audioSwitch.ChangeIcon(_isPlaying);
        _volumeEnabled.Set(_isPlaying);
        IsSwitching?.Invoke(_isPlaying);
    }
}
