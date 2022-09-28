using UnityEngine;

public class Water : MonoBehaviour, IObject
{
    [SerializeField] private ParticleSystem _surge;

    public bool CheckDamage()
    {
        return true;
    }

    public void Play()
    {
        Instantiate(_surge,transform.position,Quaternion.identity);
    }
}