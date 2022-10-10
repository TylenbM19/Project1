using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    public event Action<bool> CollisionResult;
    public event Action<bool> ReproduceVictory;

    private bool _takeDamageOnEnemy = false;
    private List<IParts> _parts = new List<IParts>();

    private void Start()
    {
        _parts.AddRange(GetComponentsInChildren<IParts>());
        Subscribe();
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    public void TakeDamage(bool TakeDamageOnEnemy)
    {
        _takeDamageOnEnemy = TakeDamageOnEnemy;
        Unhook();
        PassArgumetForLosingWin();
    }

    public void Unhook()
    {
        CollisionResult?.Invoke(true);
    }

    private void Subscribe()
    {
        if (_parts.Count == 0)
            return;

        foreach (var part in _parts)
        {
            part.FacedForFinishPoint += PassArgumetForLosingWin;
        }
    }

    private void Unsubscribe()
    {
        if (_parts.Count == 0)
            return;

        foreach (var part in _parts)
        {
            part.FacedForFinishPoint -= PassArgumetForLosingWin;
        }
    }

    private void PassArgumetForLosingWin()
    {
        ReproduceVictory?.Invoke(_takeDamageOnEnemy);
    }
}
