using UnityEngine;

public class Water : MonoBehaviour, IObject
{
    [SerializeField] private ParticleSystem _surge;

    public bool CheckDamage()
    {
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IParts>(out IParts part))
        {
            Instantiate(_surge, other.ClosestPointOnBounds(transform.position), Quaternion.identity);
        }
    }
}