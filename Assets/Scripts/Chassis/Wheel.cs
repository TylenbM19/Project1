using DG.Tweening;
using UnityEngine;

public class Wheel : MonoBehaviour 
{
    private int _duration = 1;

    public void EnableRotation()
    {
        Movement();
    }

    public void Movement()
    {
        transform.DORotate(new Vector3(0, 360, 0), _duration, RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
    }
}
