using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour , IEnemy
{
    public event UnityAction<bool> CollisionResult;

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

    private void Subscribe()
    {
        if (_parts.Count == 0)
            return;

        foreach (var part in _parts)
        {
            part.Faced += CheckResult;
        }
    }

    private void Unsubscribe()
    {
        if (_parts.Count == 0)
            return;

        foreach (var part in _parts)
        {
            part.Faced -= CheckResult;
        }
    }

    private void CheckResult(bool result)
    {
        Debug.Log(result);
        CollisionResult?.Invoke(result);
    }
}
