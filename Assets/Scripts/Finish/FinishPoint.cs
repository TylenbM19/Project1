using System;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private Player _player;

    public event Action ReproduceEffect;

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
    }

    private  void DisableThis()
    {
        this.enabled = false;
    }
}
