using DG.Tweening;
using UnityEngine;

public class FinishButton : MonoBehaviour
{
    [SerializeField] private FinishPoint _finishPoint;
    [SerializeField] private Animator _pushButtonAnimation;

    private const string _nameAnimation = "finishButton";

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
        _pushButtonAnimation.Play(_nameAnimation);
    }
}
