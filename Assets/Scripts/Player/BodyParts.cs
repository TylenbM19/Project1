using System;
using System.Collections.Generic;
using UnityEngine;

public class BodyParts : MonoBehaviour, IParts
{
    [SerializeField] private ParticleSystem _blood;

    private List<IPlayer> _players = new List<IPlayer>();

    public event Action<bool> Faced;
    public event Action FacedForFinishPoint;

    private void Start()
    {
        _players.AddRange(GetComponentsInParent<IPlayer>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IObject>(out IObject enemy))
        {
            foreach (IPlayer player in _players)
            {
                player.TakeDamage(enemy.ApplyDamage());
            }
        }

        if (other.TryGetComponent<FinishPoint>(out FinishPoint finishPoint))
        {
            Faced?.Invoke(true);
            FacedForFinishPoint?.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<SharpObject>(out SharpObject enemy))
        {
            Instantiate(_blood, collision.GetContact(0).point, Quaternion.identity);
        }
    }
}
