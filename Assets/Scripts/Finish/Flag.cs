using DG.Tweening;
using UnityEngine;

public class Flag : MonoBehaviour
{

    private void Rotate()
    {
        transform.DORotate(new Vector3(3, 0, 0), 0.1f).SetLoops(-1, LoopType.Yoyo);
    }
}
