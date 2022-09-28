using DG.Tweening;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private Flag _flag;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _point;

    private int _duration = 1;

    private void OnEnable()
    {
        _player.ReproduceVictory += Reproduce;
        _player.GotGamage += DisableThis;
    }

    private void OnDisable()
    {
        _player.ReproduceVictory -= Reproduce;
        _player.GotGamage -= DisableThis;
    }

    private void Reproduce()
    {
        PushButton();
    }

    private  void DisableThis()
    {
        this.enabled = false;
    }

    private void PushButton()
    {
        transform.DOMove(_point.transform.position, 0.2f).SetLoops(-1, LoopType.Yoyo);
    }
}
