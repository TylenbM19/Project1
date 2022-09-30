using System;
using System.Collections.Generic;
using UnityEngine;

public class BodyParts : MonoBehaviour, IParts
{
    private List<IPlayer> _players = new List<IPlayer>();

    public event Action<bool> Faced;
    public event Action FacedForFinishPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IObject>(out IObject enemy))
        {
            foreach(IPlayer player in _players)
            {
                player.TakeDamage(enemy.CheckDamage());
            }
            Faced?.Invoke(true);
        }

        if (other.TryGetComponent<FinishPoint>(out FinishPoint finishPoint))
        {
            Faced?.Invoke(true);
            FacedForFinishPoint?.Invoke();
        }
    }
}
