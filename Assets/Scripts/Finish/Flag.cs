using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private FinishPoint finishPoint;

    private int _duration = 1;


    private void Rotate()
    {
        transform.DORotate(new Vector3(0, -360, 0), _duration, RotateMode.Fast).SetLoops(-1).SetEase(Ease.Linear);
    }
}
