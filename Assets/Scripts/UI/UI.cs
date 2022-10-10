using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI : MonoBehaviour , IUi
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private AudioSource _playSoundPushButton;

    public void EnableCanvasGroup() => _canvasGroup.gameObject.SetActive(true);
    public void DisableCanvasGroup() => _canvasGroup.gameObject.SetActive(false);
    public void PlaySoundPushButtom() => _playSoundPushButton.Play();
}
