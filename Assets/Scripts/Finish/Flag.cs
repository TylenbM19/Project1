using DG.Tweening;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private FinishPoint _finishPoint;

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
        transform.DORotate(new Vector3(0, 0, 0), 0.1f).SetLoops(1);
    }
}
