using UnityEngine;

public class Water : MonoBehaviour, IObject
{
    [SerializeField] private ParticleSystem _surge;

    public bool CheckDamage()
    {
        return true;
    }
}