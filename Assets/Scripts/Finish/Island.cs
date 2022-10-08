using UnityEngine;

public class Island : MonoBehaviour, IObject
{
    [SerializeField] private ParticleSystem _dustEffect;
    public bool CheckDamage()
    {
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IParts>(out IParts part))
        {
            Instantiate(_dustEffect,other.ClosestPointOnBounds(transform.position), Quaternion.identity);
        }
    }
}
