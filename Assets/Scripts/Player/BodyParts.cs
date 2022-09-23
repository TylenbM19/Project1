using UnityEngine;
using UnityEngine.Events;

public class BodyParts : MonoBehaviour, IParts
{
    public event UnityAction<bool> Faced;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IEnemy>(out IEnemy enemy))
        {
            Faced?.Invoke(true);
        }
    }
}
