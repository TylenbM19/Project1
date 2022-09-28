using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour 
{
    public event UnityAction<bool> CollisionResult;
    public event UnityAction ReproduceVictory;
    public event UnityAction GotGamage;

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

        if(_takeDamageOnEnemy)
            GotGamage?.Invoke();
    }

    private void Subscribe()
    {
        if (_parts.Count == 0)
            return;

        foreach (var part in _parts)
        {
            part.Faced += CollisionWithObject;
            part.FacedForFinishPoint += PassArgumetForLosingWin;
        }
    }

    private void Unsubscribe()
    {
        if (_parts.Count == 0)
            return;

        foreach (var part in _parts)
        {
            part.Faced -= CollisionWithObject;
            part.FacedForFinishPoint += PassArgumetForLosingWin;
        }
    }

    private void CollisionWithObject(bool result)
    {
        CollisionResult?.Invoke(result);
        PassArgumetForLosingWin();
    }

    private void PassArgumetForLosingWin()
    {
        if (_takeDamageOnEnemy)
            return;

        ReproduceVictory?.Invoke();
    }
}
