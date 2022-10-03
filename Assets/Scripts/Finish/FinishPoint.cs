using System;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private Player _player;

    public event Action ReproduceEffect;
    public event Action NextLeval;
    public event Action RestartLeval;

    private void OnEnable()
    {
        _player.ReproduceVictory += Reproduce;
        _player.GotGamage += DisableThis;
    }

    private void OnDisable()
    {
        _player.ReproduceVictory -= Reproduce;
        _player.GotGamage -= DisableThis;
    }

    private void Reproduce()
    {
        ReproduceEffect?.Invoke();
        NextLeval?.Invoke();
        RestartLeval?.Invoke();
    }

    private  void DisableThis()
    {
        this.enabled = false;
        RestartLeval?.Invoke();
    }
}
