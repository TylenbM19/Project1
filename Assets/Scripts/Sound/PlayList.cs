using UnityEngine;

public class PlayList : MonoBehaviour
{
    [SerializeField] private AudioSource _mainMenu;
    [SerializeField] private AudioSource _clickButton;
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private LosingVictory _uiVictory;
    [SerializeField] private Restart _restartSound;
    [SerializeField] private NextLevel _nextSound;
    [SerializeField] private SoundControl _soundControl;

    private VolumeEnabledPlayerPrefs _volumeEnabled = new VolumeEnabledPlayerPrefs();
    private bool _isPlaying ;

    private void OnEnable()
    {
        _soundControl.IsSwitching += SwitchSound;
        _uiVictory.IsWin += EbableSoundWin;
        _restartSound.IsButtonClick += EnableSoundClickButton;
        _nextSound.IsButtonClickNext += EnableSoundClickButton;
    }

    private void OnDisable()
    {
        _soundControl.IsSwitching -= SwitchSound;
        _uiVictory.IsWin -= EbableSoundWin;
        _restartSound.IsButtonClick -= EnableSoundClickButton;
        _nextSound.IsButtonClickNext -= EnableSoundClickButton;
    }

    private void Start()
    {
        _isPlaying = _volumeEnabled.Get();
        EnableSoundMainMenu();
    }

    private void SwitchSound(bool isPlaying)
    {
        _isPlaying = isPlaying;
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

    private void EbableSoundWin()
    {

        if (!_isPlaying)
        {
            _winSound.Stop();
            return;
        }
        _winSound.Play();
    }
}
