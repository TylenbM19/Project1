using UnityEngine;
using UnityEngine.Events;

public class BodyParts : MonoBehaviour, IParts
{
    [SerializeField] private Player _player;

    public event UnityAction<bool> Faced;
    public event UnityAction FacedForFinishPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IObject>(out IObject enemy))
        {
            _player.TakeDamage(enemy.CheckDamage());
            Faced?.Invoke(true);
        }

        if (other.TryGetComponent<FinishPoint>(out FinishPoint finishPoint))
        {
            Faced?.Invoke(true);
            FacedForFinishPoint?.Invoke();
        }
    }
}
