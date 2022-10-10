using DG.Tweening;
using UnityEngine;

public class FinishButton : MonoBehaviour
{
    [SerializeField] private FinishPoint _finishPoint;
    [SerializeField] private Transform[] _positoinPlayEffect;
    [SerializeField] private ParticleSystem _conffetis;

    private void Start()
    {
        //PushButton();
    }
    private void OnEnable()
    {
        _finishPoint.ReproduceEffect += PushButton;
    }

    private void OnDisable()
    {
        _finishPoint.ReproduceEffect -= PushButton;
    }

    private void PushButton()
    {
        //transform.DOMove(_point.transform.position, 0.2f).SetLoops(-1, LoopType.Yoyo);
    }
}
