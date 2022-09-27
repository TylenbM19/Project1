using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private Joint _joint;
    [SerializeField] private Player _player;

    private void Start()
    {
        _player.CollisionResult += DisableBreakForse;
    }

    private void OnDisable()
    {
        _player.CollisionResult -= DisableBreakForse;
    }

    private void DisableBreakForse(bool result)
    {
        if (result)
            _joint.gameObject.SetActive(false);
    }
}
