using System;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform[] _pointPlayParticalWin;
    [SerializeField] private ParticleSystem _conffeti;

    public event Action ReproduceEffect;
    public event Action NextLeval;
    public event Action RestartLeval;

    private void OnEnable()
    {
        _player.ReproduceVictory += Reproduce;
    }

    private void OnDisable()
    {
        _player.ReproduceVictory -= Reproduce;
    }

    private void Reproduce(bool result)
    {
        if (result)
        {
            DisableThis();
        }
        else
        {
            ReproduceEffect?.Invoke();
            NextLeval?.Invoke();
            ReproducteParticalWin();
            DisableThis();
        }
    }

    private void DisableThis()
    {
        RestartLeval?.Invoke();
        this.enabled = false;
    }

    private void ReproducteParticalWin()
    {
        foreach (Transform pointPosition in _pointPlayParticalWin)
        {
            Instantiate(_conffeti, pointPosition.position, Quaternion.Euler(-90,0,0));
        }
    }
}
