using DG.Tweening;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private FinishPoint _finishPoint;
    [SerializeField] private ColorFlag _colorFlag;

    private void OnEnable()
    {
        _finishPoint.ReproduceEffect += Rotate;
    }

    private void OnDisable()
    {
        _finishPoint.ReproduceEffect -= Rotate;
    }

    private void Rotate()
    {
        transform.DORotate(new Vector3 (0,-90f,0),0.5f,RotateMode.FastBeyond360);
    }

    private void ChangeColor()
    {
        
    }
}
