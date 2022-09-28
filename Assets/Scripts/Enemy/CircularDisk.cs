using DG.Tweening;
using UnityEngine;

public class CircularDisk : MonoBehaviour, IObject
{
    private float _duration = 3;

    private void Start ()
    {
        Rotate();
    }

    private void Rotate()
    { 
        transform.DORotate(new Vector3 (0,0,360), _duration,RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
    }

    public bool CheckDamage()
    {
        return true;
    }
}
